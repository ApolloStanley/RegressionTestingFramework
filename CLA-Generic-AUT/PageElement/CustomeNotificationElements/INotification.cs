using CLA_Generic_AUT.PageElement.InlineStaticElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.CustomeNotificationElements
{
    public interface INotification
    {
        public DivElement NotificationContainer { get; set; }
    }
}
