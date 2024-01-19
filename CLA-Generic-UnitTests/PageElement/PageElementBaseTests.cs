using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLA_Generic_AUT.PageElement;
using OpenQA.Selenium;
using CLA_Generic_UnitTests.HTML;

namespace CLA_Generic_UnitTests.PageElement
{
    public class PageElementBaseTests
    {

        private IWebHandler GetWebHandler()
        {
            var myFactory = new WebHandlerFactory();

            var config = WebHandlerConfigMapper.GetWebHandlerConfig();

            return myFactory.CreateHandler(config);
        }

        [Fact]
        public void PageElementBase_GivenATestPageWebElement_GetTheAttributeValue()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var checkbox = new InputBoxElement(By.Id("vehicle1"), webHandler, new TimeSpan(0, 0, 20));

                Assert.Equal("Bike", checkbox.AttributeValue("value"));
            }
        }
    }
}
