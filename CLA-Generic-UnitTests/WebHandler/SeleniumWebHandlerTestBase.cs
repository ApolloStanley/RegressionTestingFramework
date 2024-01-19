using CLA_Generic_AUT.WebHandler;
using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_UnitTests.HTML;
using OpenQA.Selenium;
using System.Diagnostics;
using Xunit;

namespace CLA_Generic_UnitTests.WebHandler
{
    public abstract class SeleniumWebHandlerTestBase
    {
        private readonly HandlerType _handlerType;

        public SeleniumWebHandlerTestBase(HandlerType handlerToTest)
        {
            _handlerType = handlerToTest;
        }

        private IWebHandler CreatTestHandler()
        {
            var config = new WebHandlerConfig();

            config.Handler = _handlerType;
            config.OptionalParameters.Add("--headless");
            config.ResolutionX = 1920;
            config.ResolutionY = 1080;

            var factory = new WebHandlerFactory();

            return factory.CreateHandler(config);
        }

        [Fact]
        public void WebHandlerFactory_GivenABlankConfig_ExpectArugmentException()
        {
            var config = new WebHandlerConfig();

            var factory = new WebHandlerFactory();

            Assert.Throws<ArgumentException>(() => factory.CreateHandler(config));
        }

        [Fact]
        public void WebHandlerFactory_GivenAWehbHandlerConfig_CreatesAssociatedDriver()
        {
            using (var browser = CreatTestHandler())
            {
                Assert.NotNull(browser);
            }
        }

        [Fact]
        public void GetElements_GivenTestUrl_Returns2Divs()
        {
            using (var browser = CreatTestHandler())
            {

                browser.Navigate(TestData.basicPageAddress);
                var div = browser.GetElements(By.XPath("//div"));

                foreach (var item in div)
                {
                    Debug.WriteLine(item.Text);
                    Assert.NotEmpty(item.Text);
                }

                Assert.Equal(3, div.Count());
            }
        }

        [Fact]
        public void GetElement_GivenTestUrl_Returns1Div()
        {
            using (var browser = CreatTestHandler())
            {

                browser.Navigate(TestData.basicPageAddress);
                var div = browser.GetElements(By.Id("TestId"));

                Assert.Equal(1, div.Count());
            }
        }

    }
}