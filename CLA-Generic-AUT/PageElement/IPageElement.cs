using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement
{
    public interface IPageElement
    {
        bool IsDisplayed { get; }

        bool IsEnabled { get; }

        bool IsSelected { get; }

        public string TagName { get; }

        public string Text { get; }

        public void Click ();

        public string AttributeValue(string attribute);

    }
}
