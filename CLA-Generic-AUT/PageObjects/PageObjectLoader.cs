using AngleSharp.Io;
using CLA_Generic_AUT.PageElement;
using CLA_Generic_AUT.PageObjects.Attributes;
using CLA_Generic_AUT.WebHandler;
using log4net;
using log4net.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]


namespace CLA_Generic_AUT.PageObjects
{
    public static class PageObjectLoader<T> where T : IPageObject
    {

        public static IPageObject LoadPageObject(IWebHandler webHandler, string URL, bool navToPage = true)
        {
            var newPage = Activator.CreateInstance(typeof(T), new object[] { webHandler, URL }) as IPageObject;

            if (newPage == null)
            {
                throw new Exception($"Could not create page {URL}");
            }

            if (navToPage) { newPage.NavigateTo(); }

            LoadElements(newPage, webHandler);

            return newPage;
        }

        public static IPageObject LoadPageObject(IWebHandler webHandler)
        {
            var newPage = Activator.CreateInstance(typeof(T), new object[] { webHandler }) as IPageObject;

            LoadElements(newPage, webHandler);

            return newPage;
        }

        public static void LoadElements(IPageObject pageObject, IWebHandler webHandler)
        {          
            var elementLoadingController = new ElementLoading.ElementLoadingController();
            elementLoadingController.LoadElements(pageObject, webHandler);

            elementLoadingController.Run();
        }
    }
}
