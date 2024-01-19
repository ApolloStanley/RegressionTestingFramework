using CLA_Generic_AUT.PageElement.CustomePageElements;
using CLA_Generic_AUT.PageObjects.Attributes;
using CLA_Generic_AUT.WebHandler;
using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CLA_Generic_AUT.PageElement.CustomeNotificationElements
{
    public class NotificationParentObject<T> : PageElementBase where T : INotification
    {

        private IWebHandler webHandler;
        public List<NotificationChildObjects<T>> LatestNotifications { get; set; }

        bool Clicked;

        public NotificationParentObject(By by, IWebHandler webHandler) : base(by, webHandler)
        {
            this.webHandler = webHandler;
        }

        public void ClearOrLoadLastNotifications()
        {
            this.Click();
            Clicked = true;

            var childType = typeof(T);
            var childProperties = childType.GetProperties().FirstOrDefault();
            var attributes = childProperties.GetCustomAttributes(typeof(ElementPathAttributeBase), true);
            var pathAttribute = attributes.FirstOrDefault() as ElementPathAttributeBase;

            LatestNotifications = webHandler.GetElements(pathAttribute.GetElementPath()).Select(x => new NotificationChildObjects<T>(x)).ToList(); 
        }

        public void CloseNoticiations()
        {
            if (Clicked)
            {
                this.Click();
            }
        }
    }
}
