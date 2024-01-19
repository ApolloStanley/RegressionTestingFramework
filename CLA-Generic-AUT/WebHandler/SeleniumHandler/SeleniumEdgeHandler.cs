using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Drawing;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Edge;
using CLA_Generic_AUT.WebHandler.Config;
using WebDriverManager.Helpers;
using OpenQA.Selenium.Chrome;

namespace CLA_Generic_AUT.WebHandler.SeleniumHandler
{
    public class SeleniumEdgeHandler : SeleniumBase
    {
        public SeleniumEdgeHandler(WebHandlerConfig webHandlerConfig)
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddArguments(webHandlerConfig.OptionalParameters);
            if (!string.IsNullOrEmpty(webHandlerConfig.ProfilePreferences.Key) && !string.IsNullOrEmpty(webHandlerConfig.ProfilePreferences.Value))
            {
                edgeOptions.AddAdditionalEdgeOption(webHandlerConfig.ProfilePreferences.Key, webHandlerConfig.ProfilePreferences.Value);
            }


            //insert browser specific config here

            new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = new EdgeDriver(edgeOptions);

            SetBaseConfig(webHandlerConfig);
        }

    }
}
