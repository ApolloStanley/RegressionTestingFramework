using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CLA_Generic_UnitTests.WebHandler.Config
{
    public class WebHandlerConfigMapperTests
    {

        [Fact]
        public void GetWebHandlerConfig_GivenInvalidFilePath_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => WebHandlerConfigMapper.GetWebHandlerConfig("rubbish.file"));
        }

        [Fact]
        public void GetWebHandlerConfig_GivenNoSource_ReturnsDefaultConfig()
        {
            var config = WebHandlerConfigMapper.GetWebHandlerConfig();

            Assert.Equal(HandlerType.SeleniumChrome, config.Handler);
            Assert.Single(config.OptionalParameters);
            Assert.Contains(config.OptionalParameters, x => x == "--headless");
            Assert.NotNull(config.ResolutionX);
            Assert.NotNull(config.ResolutionY);
        }

        [Fact]
        public void GetWebHandlerConfig_GivenTestFilePath_ReturnsTestConfig()
        {
            var testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "WebHandler\\Config\\TestDefaultWebHandlerConfig.json");
            var config = WebHandlerConfigMapper.GetWebHandlerConfig(testFilePath);

            Assert.Equal(HandlerType.SeleniumEdge, config.Handler);
            Assert.Single(config.OptionalParameters);
            Assert.Contains(config.OptionalParameters, x => x == "--headless2");
            Assert.NotNull(config.ResolutionX);
            Assert.NotNull(config.ResolutionY);
            Assert.Equal(1980, config.ResolutionX);
            Assert.Equal(1024, config.ResolutionY);
        }

        [Theory]
        [InlineData(new object[] { HandlerType.SeleniumChrome, null, null, null, null })]
        [InlineData(new object[] { HandlerType.SeleniumChrome, "--headless", null, null, null })]
        [InlineData(new object[] { HandlerType.SeleniumChrome, "--headless", null, 1980, 1024 })]
        public void GetWebHandlerConfig_GivenSettings_ReturnsMatchingConfig(HandlerType handlerType, string? optionalParameter, KeyValuePair<string,string>? ProfilePreferences, int? resX, int? resY)
        {
            var paramList = new List<string>();
            if (!string.IsNullOrEmpty(optionalParameter)) { paramList.Add(optionalParameter); }

            var config = WebHandlerConfigMapper.GetWebHandlerConfig(handlerType, paramList, ProfilePreferences, resX, resY);

            Assert.Equal(handlerType, config.Handler);

            if (!string.IsNullOrEmpty(optionalParameter))
            {
                Assert.Single(config.OptionalParameters);
                Assert.Contains(config.OptionalParameters, x => x == optionalParameter);
            }
            else
            {
                Assert.Empty(config.OptionalParameters);
            }

            Assert.Equal(resX, config.ResolutionX);
            Assert.Equal(resY, config.ResolutionY);
        }
    }
}
