
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.WebHandler.Config
{

    public enum HandlerType
    {
        NotSet, SeleniumChrome, SeleniumFirefox, SeleniumEdge
    }

    public class WebHandlerConfig
    {
        [EnvironmentAttributes("HandlerType")]
        public HandlerType Handler { get; set; } = HandlerType.NotSet;

        [EnvironmentAttributes("OptionalParameters")]
        public List<string> OptionalParameters { get; set; } = new List<string>() { "--headless" };

        [EnvironmentAttributes("UserProfilePreferences")]
        public KeyValuePair<string, string> ProfilePreferences { get; set; } = new KeyValuePair<string, string>("", "");

        [EnvironmentAttributes("ResolutionX")]
        public int? ResolutionX { get; set; } = 1920;

        [EnvironmentAttributes("ResolutionY")]
        public int? ResolutionY { get; set; } = 1080;

        [EnvironmentAttributes("NumberOfElementLoadingThreads")]
        public int NumberOfElementLoadingThreads { get; set; } = 20;

        [EnvironmentAttributes("ElementLoadingTimeOut")]
        public TimeSpan ElementLoadingTimeOut { get; set; } = new TimeSpan(0, 0, 20);

        [EnvironmentAttributes("MatSelectWaitTime")]
        public int MatSelectWaitTime { get; set; } = 1000;
    }
}
