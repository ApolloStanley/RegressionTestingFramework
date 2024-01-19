using CLA_Generic_AUT.PageElement;
using CLA_Generic_AUT.PageObjects;
using CLA_Generic_AUT.PageObjects.Attributes;
using CLA_Generic_AUT.WebHandler;

namespace SpecflowTemplate.ExamplePageObjects
{
    public class TestPageObjectsNegative: PageObjectBase
    {
        public TestPageObjectsNegative(IWebHandler webHandler, string URL) : base(webHandler, URL)
        {
        }

        [xPathsAttributes("//*[@Id='Rubbish']")]
        public BasicButtonElement RubbishElement { get; set; }

        [xPathsAttributes("//*[@id='fname']")]
        public InputBoxElement FirstNameBox { get; set; }
    }
}
