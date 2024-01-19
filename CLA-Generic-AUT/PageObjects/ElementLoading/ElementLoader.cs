using CLA_Generic_AUT.PageObjects.Attributes;
using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageObjects.ElementLoading
{
    public class ElementLoader
    {
        private object webHandlerLock;
        private DateTime startTime;
        private Random random;

        public IWebHandler WebHandler { get; set; }
        public IPageObject ParentPage { get; set; }
        public PropertyInfo ParentPageProperty { get; set; }
        public Type ElementToLoad { get; set; }
        public By ElementPath { get; set; }
        public TimeSpan TimeOut { get; set; }

        public ElementLoader(IWebHandler webHandler, IPageObject parentPage, PropertyInfo parentPageProperty,  Type elementToLoad, By elementPath, TimeSpan timeOut, object webHandlerLock)
        {
            WebHandler = webHandler;
            ParentPage = parentPage;
            ParentPageProperty = parentPageProperty;
            ElementToLoad = elementToLoad;
            ElementPath = elementPath;
            TimeOut = timeOut;
            this.webHandlerLock = webHandlerLock;

            startTime = DateTime.Now;
            random = new Random();
        }

        public void LoadElement()
        {
            bool loadedElement = false;

            while (!loadedElement && DateTime.Now <= startTime.Add(TimeOut))
            {
                lock (webHandlerLock)
                {
                    try
                    {
                        var newElement = Activator.CreateInstance(ElementToLoad, new object[] { ElementPath, WebHandler });
                        ParentPageProperty.SetValue(ParentPage, newElement);

                        loadedElement = true;
                    }
                    catch (Exception)
                    {
                        //ignore excpetion
                    }
                }

                if (!loadedElement) { Thread.Sleep(random.Next(100, 2000)); }
            }

            if (!loadedElement)
            {
                ParentPageProperty.SetValue(ParentPage, null);
            }
        }
    }
}
