using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler.SeleniumHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.WebHandler
{
    public class WebHandlerFactory
    {

        private static Dictionary<HandlerType, Type> AvailableWebHandler = new Dictionary<HandlerType, Type>()
        {
            { HandlerType.SeleniumChrome, typeof(SeleniumChromeHandler) },
            { HandlerType.SeleniumEdge, typeof(SeleniumEdgeHandler) },
            { HandlerType.SeleniumFirefox, typeof(SeleniumFirefoxHandler) }
        };

        public IWebHandler CreateHandler(WebHandlerConfig config)
        {
            if(config.Handler == HandlerType.NotSet) { throw new ArgumentException("No browser/driver type set"); }

            var myDriver = AvailableWebHandler[config.Handler];

            var handler = Activator.CreateInstance(myDriver, new object[] { config }) as IWebHandler;

            if (handler == null)
            {
                throw new ArgumentNullException();
            }

            return handler;
        }
    }
}