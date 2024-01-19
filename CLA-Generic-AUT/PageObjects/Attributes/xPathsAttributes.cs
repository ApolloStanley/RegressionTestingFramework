using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageObjects.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class xPathsAttributes : ElementPathAttributeBase
    {
        public xPathsAttributes(string value)
        {
            ElementPath = value;
        }

        public override By GetElementPath()
        {
            return By.XPath(ElementPath);
        }
    }
}
