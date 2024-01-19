using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLA_Generic_AUT.PageElement;
using CLA_Generic_UnitTests.HTML;
using OpenQA.Selenium;
using CLA_Generic_AUT.PageElement.InlineStaticElements;

namespace CLA_Generic_UnitTests.PageElement
{
    public class BasicButtonElementTests
    {
        private IWebHandler GetWebHandler()
        {
            var myFactory = new WebHandlerFactory();

            var config = WebHandlerConfigMapper.GetWebHandlerConfig();

            return myFactory.CreateHandler(config);
        }

        [Fact]
        public void BasicButtonElement_GivenABogusInputXPath_ThrowsAnException()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                Assert.Throws<WebDriverTimeoutException>(() => new BasicButtonElement(By.XPath("//*[@id=\"rubbish\"]"), webHandler, new TimeSpan(0,0,20)));
            }
        }

        [Fact]
        public void BasicButtonElement_GivenTheTestPageButtonXPath_LoadsTheCorrespondingButton()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var button = new BasicButtonElement(By.XPath("/html/body/section[1]/button"), webHandler, new TimeSpan(0, 0, 20));

                Assert.NotNull(button);
            }
        }

        [Fact]
        public void BasicButton_GivenAnButtonWhenWeClickIt_TheJavascriptIsFiredAndTheTextFieldsUpdate()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var inputBox1 = new InputBoxElement(By.XPath("//*[@id=\"fname\"]"), webHandler);
                var inputBox2 = new InputBoxElement(By.XPath("//*[@id=\"lname\"]"), webHandler);

                inputBox1.SetText("foo");
                inputBox2.SetText("bar");

                var button = new BasicButtonElement(By.XPath("/html/body/section[1]/button"), webHandler, new TimeSpan(0, 0, 20));

                button.ClickButton();

                var div = new DivElement(By.XPath("//div[@id='results']"),webHandler);

                Assert.Equal("foo bar", div.GetText());
            }
        }

        [Fact]
        public void BasicButton_GivenAnButtonWhenWeGetItstextValue_ClickMeIsReturned()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var button = new BasicButtonElement(By.XPath("/html/body/section[1]/button"), webHandler, new TimeSpan(0, 0, 20));

                Assert.Equal("Click Me!", button.GetButtonText());
            }
        }
    }
}
