using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using TechTalk.SpecFlow;
using System.Reflection.Metadata.Ecma335;

namespace SpecflowTemplate
{
    public class ClaBaseSpecFlowStepDef

    {
        public IWebHandler WebHandler { get; set; }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            var config = WebHandlerConfigMapper.GetWebHandlerConfig();
            var factory = new WebHandlerFactory();

            WebHandler = factory.CreateHandler(config);
        }



        [AfterScenario]
        public void AfterScenario()
        {
            WebHandler.Dispose();
        }
    }
}