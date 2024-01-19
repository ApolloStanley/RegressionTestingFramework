using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLA_Generic_AUT.PageElement.InlineStaticElements;
using OpenQA.Selenium;
using CLA_Generic_UnitTests.HTML;
using CLA_Generic_AUT.PageElement;

namespace CLA_Generic_UnitTests.PageElement
{
    public class ListElementTests
    {

        private IWebHandler GetWebHandler()
        {
            var myFactory = new WebHandlerFactory();

            var config = WebHandlerConfigMapper.GetWebHandlerConfig();

            return myFactory.CreateHandler(config);
        }


        [Fact]
        public void ListElement_GivenACorrectListXPath_ElementIsPresent()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var listElement = new ListsElement(By.XPath("//ol"), webHandler, new TimeSpan(0, 0, 20));

                Assert.True(listElement.ListElements.Count > 1);
            }
        }

        [Fact]
        public void ListElement_GivenACorrectListXPath_ChildElementsCanBeAccessed()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var listElements = new ListsElement(By.XPath("//ol"), webHandler, new TimeSpan(0, 0, 20));

                var subListElements = listElements.SelectSubListElementByPartialText(By.XPath(".//p"), "Tea");

                Assert.Equal("Further Detail about Tea", subListElements.Text);
            }
        }
    }
}
