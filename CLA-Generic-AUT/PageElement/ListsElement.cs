using AngleSharp.Dom;
using CLA_Generic_AUT.PageElement.Tables;
using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CLA_Generic_AUT.PageElement
{
    public class ListsElement : PageElementBase
    {
        public List<IWebElement> ListElements { get; set; }
        public List<IWebElement> SubListElements { get; set; } = null;

        public ListsElement(By by, IWebHandler webHandler) : base(by, webHandler)
        {
            LoadListElement();
        }

        public ListsElement(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
            LoadListElement();
        }

        private void LoadListElement() 
        {
            ListElements = ThisElement.FindElements(By.XPath(".//li")).ToList();
        }

        private void LoadSubListElements(By by)
        {
            SubListElements = ListElements.Select(x => x.FindElement(by)).ToList();
        }

        public IWebElement SelectSubListElementByPartialText(By subElementToLoad, string text)
        {
            LoadSubListElements(subElementToLoad);
            var results = SubListElements.Where(x => x.Text.ToLower().Contains(text.ToLower())).ToList();

            return SelectItemFromListByText(SubListElements, text);
        }

        public IWebElement SelectItemFromLiElement(string text)
        {
            return SelectItemFromListByText(ListElements, text);
        }

        private IWebElement SelectItemFromListByText(List<IWebElement> elements, string text)
        {
            var results = elements.Where(x => x.Text.ToLower().Contains(text.ToLower())).ToList();


            if (results.Count == 0)
            {
                throw new Exception("No options found");

            }

            if (results.Count > 1)
            {
                throw new Exception("None unique text provided");
            }

            return results[0];
        }
    }
}
