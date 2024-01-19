using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using CLA_Generic_AUT.PageObjects;
using CLA_Generic_UnitTests.HTML;
using OpenQA.Selenium;
using System.Reflection;
using SpecflowTemplate.ExamplePageObjects;
using System.Diagnostics;

namespace CLA_Generic_UnitTests.PageObjects
{
    public class PageObjectsTests
    {

        private IWebHandler CreatTestHandler()
        {
            var config = WebHandlerConfigMapper.GetWebHandlerConfig();
            config.OptionalParameters.Add("--headless");
            var factory = new WebHandlerFactory();

            return factory.CreateHandler(config);
        }

        [Fact]
        public void PageObjectCreation_GivenTestPageType_CreatesANewTestPage()
        {
            using (var driver = CreatTestHandler())
            {
                var pageObject = PageObjectLoader <TestPageObject>.LoadPageObject(driver, TestData.basicPageAddress, true);

                Assert.NotNull(pageObject);

                var testPage = (TestPageObject)pageObject;

                Assert.NotNull(testPage.FirstNameBox);
            }               
        }

        [Fact]
        public void PageObjectCreation_GivenTestPageType_TimesOutWhenSuppliedWithIncorrectPageElements()
        {
            using (var driver = CreatTestHandler())
            {

                var testPage = PageObjectLoader<TestPageObjectsNegative>.LoadPageObject(driver, TestData.basicPageAddress, true) as TestPageObjectsNegative;

                Assert.Null(testPage.RubbishElement);
                Assert.Throws<NullReferenceException>(() => testPage.RubbishElement.ClickButton());
            }
        }

    }
}
