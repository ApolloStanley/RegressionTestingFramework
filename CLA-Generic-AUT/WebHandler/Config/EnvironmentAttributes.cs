using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.WebHandler.Config
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EnvironmentAttributes: Attribute
    {
        string EnvironmentName;
        public EnvironmentAttributes(string value)
        {
            EnvironmentName = value;
        }

        public string GetElementValue()
        {
            return EnvironmentName;
        }
    }
}
