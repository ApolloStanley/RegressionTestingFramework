using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageObjects.Attributes
{
    public class classNamePathsAttributes: ElementPathAttributeBase
    {
        public classNamePathsAttributes(string value)
        {
            ElementPath = value;
        }

        public override By GetElementPath()
        {
            return By.ClassName(ElementPath);
        }
    }
}
