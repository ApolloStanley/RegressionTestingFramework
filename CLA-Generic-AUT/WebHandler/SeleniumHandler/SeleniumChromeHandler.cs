using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using System.Drawing;
using CLA_Generic_AUT.WebHandler.Config;
using OpenQA.Selenium.Firefox;

namespace CLA_Generic_AUT.WebHandler.SeleniumHandler
{
    public class SeleniumChromeHandler : SeleniumBase
    {
        public SeleniumChromeHandler(WebHandlerConfig webHandlerConfig)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(webHandlerConfig.OptionalParameters);

            if (!string.IsNullOrEmpty(webHandlerConfig.ProfilePreferences.Key) && !string.IsNullOrEmpty(webHandlerConfig.ProfilePreferences.Value))
            {
                chromeOptions.AddUserProfilePreference(webHandlerConfig.ProfilePreferences.Key, webHandlerConfig.ProfilePreferences.Value);
            }

            //insert browser specific config here

            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver(chromeOptions);

            SetBaseConfig(webHandlerConfig);
        }
    }
}