using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLA_Generic_UnitTests.HTML;
using CLA_Generic_AUT.PageElement;
using OpenQA.Selenium;

namespace CLA_Generic_UnitTests.PageElement
{
    public class InputBoxElementTests
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

                Assert.Throws<WebDriverTimeoutException>(() => new InputBoxElement(By.XPath("//*[@id=\"rubbish\"]"), webHandler, new TimeSpan(0, 0, 20)));
            }
        }

        [Fact]
        public void InputBoxElement_GivenTheTestPageInputXPath_LoadsTheCorrespondingInputBox()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var inputBox = new InputBoxElement(By.XPath("//*[@id=\"fname\"]"), webHandler, new TimeSpan(0, 0, 20));

                Assert.NotNull(inputBox);
            }
        }

        [Fact]
        public void InputBoxElement_GivenAnInputBoxWhenWeSetText_InputBoxIsUpdatedWithTheText()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var inputBox = new InputBoxElement(By.XPath("//*[@id=\"fname\"]"), webHandler, new TimeSpan(0, 0, 20));

                inputBox.SetText("hello world");

                Assert.Equal("hello world", inputBox.GetText());
            }          
        }

        [Fact]
        public void InputBoxElement_GivenAnInputBoxWhenWeClearText_InputBoxValueIsWiped()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var inputBox = new InputBoxElement(By.XPath("//*[@id=\"fname\"]"), webHandler, new TimeSpan(0, 0, 20));

                inputBox.SetText("hello world");

                inputBox.ClearText();

                Assert.Equal("", inputBox.GetText());
            }
        }
    }
}
