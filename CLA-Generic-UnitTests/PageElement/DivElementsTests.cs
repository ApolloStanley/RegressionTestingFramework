using CLA_Generic_AUT.PageElement;
using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLA_Generic_UnitTests.HTML;
using CLA_Generic_AUT.PageElement.InlineStaticElements;

namespace CLA_Generic_UnitTests.PageElement
{
    public class DivElementsTests
    {
        private IWebHandler GetWebHandler()
        {
            var myFactory = new WebHandlerFactory();

            var config = WebHandlerConfigMapper.GetWebHandlerConfig();

            return myFactory.CreateHandler(config);
        }

        [Fact]
        public void DivElement_GivenACorrectDivXPath_ElementIsPresent()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var divElement = new DivElement(By.XPath("//*[@id=\"TestId\"]"), webHandler, new TimeSpan(0, 0, 20));

                Assert.True(divElement.IsDisplayed);
            }
        }

        [Fact]
        public void AnchorElement_GivenACorrectAnchorXPath_HtmlRefIsReturned()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var anchorElement = new AnchorElement(By.XPath("//*[@id=\"TestHrefId\"]"), webHandler, new TimeSpan(0, 0, 20));

                Assert.Equal("visit cla",anchorElement.GetText().ToLower().Trim());
                Assert.Equal("http://www.cla.co.uk/", anchorElement.GetHref());
                
            }
        }

        [Fact]
        public void HeaderElement_GivenACorrectAnchorXPath_HeaderSizeIsReturned()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var headerElement = new HeaderElement(By.XPath("//*[@id=\"HeaderText\"]"), webHandler, new TimeSpan(0, 0, 20));

                Assert.Equal("Heading text", headerElement.GetText());
                Assert.Equal(1, headerElement.GetSize());

            }
        }
    }
}
