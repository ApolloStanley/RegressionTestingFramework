using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageObjects.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ElementPathAttributeBase: Attribute
    {
        protected string ElementPath;

        public abstract By GetElementPath();
    }
}
