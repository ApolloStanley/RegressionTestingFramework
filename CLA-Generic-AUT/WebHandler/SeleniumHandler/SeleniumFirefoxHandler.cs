using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Firefox;
using CLA_Generic_AUT.WebHandler.Config;

namespace CLA_Generic_AUT.WebHandler.SeleniumHandler
{
    // Why inherit from IWebHandler here if no methods from interface are used
    public class SeleniumFirefoxHandler : SeleniumBase
    {
        public SeleniumFirefoxHandler(WebHandlerConfig webHandlerConfig)
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments(webHandlerConfig.OptionalParameters);
            if (!string.IsNullOrEmpty(webHandlerConfig.ProfilePreferences.Key) && !string.IsNullOrEmpty(webHandlerConfig.ProfilePreferences.Value))
            {
                firefoxOptions.SetPreference(webHandlerConfig.ProfilePreferences.Key, webHandlerConfig.ProfilePreferences.Value);
            }

            //insert browser specific config here
            var x = new FirefoxConfig();

            new DriverManager().SetUpDriver(new FirefoxConfig());
            _driver = new FirefoxDriver(firefoxOptions);

            SetBaseConfig(webHandlerConfig);
        }
    }
}
