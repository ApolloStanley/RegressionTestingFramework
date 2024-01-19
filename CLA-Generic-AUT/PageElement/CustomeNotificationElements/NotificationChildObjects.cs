using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLA_Generic_AUT.PageElement.CustomePageElements;
using CLA_Generic_AUT.PageObjects.Attributes;
using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;

namespace CLA_Generic_AUT.PageElement.CustomeNotificationElements
{
    public class NotificationChildObjects<T> : PageElementBase where T : INotification
    {
        public T Notification { get; private set; }
        public NotificationChildObjects(IWebElement element) : base(element)
        {
            loadOjects();
        }

        private void loadOjects()
        {
            var childType = typeof(T);

            var childProperties = childType.GetProperties();

            Notification = (T)Activator.CreateInstance(childType);

            foreach (var prop in childProperties)
            {
                try
                {
                    var attributes = prop.GetCustomAttributes(typeof(ElementPathAttributeBase), true);
                    var pathAttribute = attributes.FirstOrDefault() as ElementPathAttributeBase;
                    var newValue = ThisElement.FindElement(pathAttribute.GetElementPath()).Text;

                    prop.SetValue(Notification, newValue);
                }
                catch
                {
                    // ignore exception
                }
            }
        }
    }

}
