using CLA_Generic_AUT.PageElement.InlineStaticElements;
using CLA_Generic_AUT.PageElement;
using CLA_Generic_AUT.PageObjects.Attributes;
using CLA_Generic_AUT.PageObjects;
using CLA_Generic_AUT.WebHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecflowTemplate.ExamplePageObjects;
using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_UnitTests.HTML;

namespace CLA_Generic_UnitTests.PageObjects
{
    internal class AttributeTestClass : PageObjectBase
    {
        public AttributeTestClass(IWebHandler webHandler, string URL) : base(webHandler, URL)
        {
        }

        [idPathsAttributes("TestId")]
        public DivElement DivById { get; set; }

        [classNamePathsAttributes("testClass")]
        public DivElement DivByClass { get; set; }

        [xPathsAttributes("//*[@id='TestId']")]
        public DivElement DivByXpath { get; set; }
    }


    public class TestAttributes
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
                var pageObject = PageObjectLoader<AttributeTestClass>.LoadPageObject(driver, TestData.basicPageAddress, true);

                Assert.NotNull(pageObject);

                var testPage = (AttributeTestClass)pageObject;

                Assert.NotNull(testPage.DivByClass);
                Assert.NotNull(testPage.DivById);
                Assert.NotNull(testPage.DivByXpath);

                Assert.Equal("This is test data", testPage.DivByClass.GetText());
                Assert.Equal("This is test data", testPage.DivById.GetText());
                Assert.Equal("This is test data", testPage.DivByXpath.GetText());
            }
        }
    }
}