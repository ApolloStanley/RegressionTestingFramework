using CLA_Generic_AUT.PageObjects.ElementLoading;
using CLA_Generic_AUT.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CLA_Generic_AUT.PageObjects.Attributes;
using System.Reflection;
using System.Reflection.Metadata;
using System.ComponentModel;


namespace CLA_Generic_AUT.WebHandler.Config
{
    public static class WebHandlerConfigMapper
    {
        private const string defaultConfigFilePath = "WebHandler\\Config\\DefaultWebHandlerConfig.json";

        private static JsonSerializerOptions defaultOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            Converters ={ new JsonStringEnumConverter( JsonNamingPolicy.CamelCase) }
        };

        public static WebHandlerConfig GetWebHandlerConfig()
        {
            //check enviroment varriables
            if (Environment.GetEnvironmentVariable("HandlerType") != null)
            {
                return setEnvVariables(new WebHandlerConfig());
            }
            else
            {
                //if env vars not set use default
                return GetWebHandlerConfig(defaultConfigFilePath);
            }
        }

        public static WebHandlerConfig GetWebHandlerConfig(HandlerType handlerType, List<string>? optionalParameters = null, KeyValuePair<string, string>? profilePreferences = null, int? reseloutionX = null, int? reseloutionY = null)
        {
            return new WebHandlerConfig()
            {
                Handler = handlerType,
                OptionalParameters = optionalParameters != null ? optionalParameters : new List<string>(),
                ProfilePreferences = (KeyValuePair<string, string>)(profilePreferences != null ? profilePreferences : new KeyValuePair<string, string>()),
                ResolutionX = reseloutionX,
                ResolutionY = reseloutionY
            };
        }

        public static WebHandlerConfig GetWebHandlerConfig(string filePath)
        {
            try
            {
                var jsonContent = File.ReadAllText(filePath);

                var configSettings = JsonSerializer.Deserialize<WebHandlerConfig>(jsonContent, defaultOptions);

                if (configSettings != null)
                {
                    return configSettings;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while loading config", ex);
            }

            throw new InvalidOperationException("Failed to load config");
        }


       
        private static WebHandlerConfig setEnvVariables(WebHandlerConfig config)
        {
            var pageProperties = config.GetType().GetProperties();

            foreach (var pageProperty in pageProperties)
            {  
                var attributes = pageProperty.GetCustomAttributes(typeof(EnvironmentAttributes), true);
                var pathAttribute = attributes.FirstOrDefault() as EnvironmentAttributes;

                var variable = Environment.GetEnvironmentVariable(pathAttribute.GetElementValue());

                if (variable != null)
                {
                    TypeConverter typeConverter = TypeDescriptor.GetConverter(pageProperty.PropertyType);
                    object propValue = typeConverter.ConvertFromString(variable);
                    pageProperty.SetValue(config, propValue);
                }
            }
            return config;
        }
    }
}
