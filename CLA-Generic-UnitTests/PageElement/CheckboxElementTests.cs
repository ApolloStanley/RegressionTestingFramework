using CLA_Generic_AUT.PageElement;
using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using CLA_Generic_UnitTests.HTML;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_UnitTests.PageElement
{
    public class CheckboxElementTests
    {
        private IWebHandler GetWebHandler()
        {
            var myFactory = new WebHandlerFactory();

            var config = WebHandlerConfigMapper.GetWebHandlerConfig();

            return myFactory.CreateHandler(config);
        }

        [Fact]
        public void InputBoxElement_GivenABogusInputXPath_ThrowsAnException()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                Assert.Throws<WebDriverTimeoutException>(() => new CheckboxElement(By.XPath("//*[@id=\"rubbish\"]"), webHandler, new TimeSpan(0, 0, 20)));
            }
        }

        [Fact]
        public void InputBoxElement_GivenTheTestPageCheckboxXPath_LoadsTheCorrespondingInputCheckbox()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var inputCheckbox = new CheckboxElement(By.XPath("//*[@id=\"vehicle1\"]"), webHandler, new TimeSpan(0, 0, 20));

                Assert.NotNull(inputCheckbox);
            }
        }

        [Fact]
        public void InputBoxElement_GivenAnInputCheckboxWhenSelect_InputCheckboxCheckedEqualsTrue()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var inputCheckbox = new CheckboxElement(By.XPath("//*[@id=\"vehicle1\"]"), webHandler, new TimeSpan(0, 0, 20));

                inputCheckbox.SelectCheckbox();

                Assert.Equal("true", inputCheckbox.GetCheckedStatus());
            }
        }

        [Fact]
        public void InputBoxElement_GivenAnInputCheckboxWhenWeDontSelect_InputCheckboxCheckedEqualsFalse()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var inputCheckbox = new CheckboxElement(By.XPath("//*[@id=\"vehicle1\"]"), webHandler, new TimeSpan(0, 0, 20));

                inputCheckbox.SelectCheckbox();

                Assert.Equal("true", inputCheckbox.GetCheckedStatus());
            }
        }
    }
}
