using CLA_Generic_AUT.PageObjects.Attributes;
using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V105.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageObjects.ElementLoading
{
    public class ElementLoadingController
    {
        private Thread[] threads;
        private int _numberOfLoadingThreads;
        private object webHandlerLock = new object();

        private Queue<ElementLoader> workQueue;

        public int NumberOfLoadingThreads 
        {
            get
            {
                return _numberOfLoadingThreads;
            }
            set
            {
                _numberOfLoadingThreads = value;
                threads = new Thread[value];
            }

        }

        public ElementLoadingController()
        {
            workQueue = new Queue<ElementLoader>();            
        }

        public void LoadElements(IPageObject pageObject, IWebHandler webHandler)
        {
            Type pageType = pageObject.GetType();
            NumberOfLoadingThreads = webHandler.HandlerConfig.NumberOfElementLoadingThreads;

            var pageProperties = pageType.GetProperties();

            foreach (var pageProperty in pageProperties)
            {
                workQueue.Enqueue(new ElementLoader(webHandler: webHandler,
                                                    parentPage: pageObject,
                                                    parentPageProperty: pageProperty,
                                                    elementToLoad: pageProperty.PropertyType,
                                                    elementPath: GetElementByPath(pageProperty),
                                                    timeOut: webHandler.HandlerConfig.ElementLoadingTimeOut,
                                                    webHandlerLock
                                                    ));
            }
        }

        public void Run()
        {
            while(workQueue.Any() || threads.Any(x => x != null && x.IsAlive))
            { 
                for (int i = 0; i < NumberOfLoadingThreads; i++)
                {
                    if (workQueue.Count > 0 && (threads[i] == null || !threads[i].IsAlive))
                    {
                        var itemOfWork = workQueue.Dequeue();

                        var newThread = new Thread(() => RunWorkItem(itemOfWork));
                        newThread.Start();

                        threads[i] = newThread;
                    }
                }
            }
        }

        private void RunWorkItem(ElementLoader elementToRun)
        {
            elementToRun.LoadElement();
        }

        private By GetElementByPath(PropertyInfo pageProperty)
        {
            var attributes = pageProperty.GetCustomAttributes(typeof(ElementPathAttributeBase), true);

            var pathAttribute = attributes.FirstOrDefault() as ElementPathAttributeBase;

            if (pathAttribute == null)
            {
                throw new Exception($"Cannot fine xpath {pageProperty.Name}");
            }

            return pathAttribute.GetElementPath();
        }
    }
}
