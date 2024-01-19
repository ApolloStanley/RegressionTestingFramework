using CLA_Generic_AUT.PageElement;
using CLA_Generic_AUT.PageObjects.Attributes;
using CLA_Generic_AUT.PageObjects;
using CLA_Generic_AUT.WebHandler;
using CLA_Generic_AUT.PageElement.InlineStaticElements;
using CLA_Generic_AUT.PageElement.Tables;

namespace SpecflowTemplate.ExamplePageObjects
{
    public class TestPageObject: PageObjectBase
    {
        public TestPageObject(IWebHandler webHandler, string URL) : base(webHandler, URL)
        {
        }

        public TestPageObject(IWebHandler webHandler) : base(webHandler)
        {
        }

        [xPathsAttributes("//*[@id='fname']")]
        public InputBoxElement FirstNameBox { get; set; }

        [xPathsAttributes("//*[@id='lname']")]
        public InputBoxElement SecondNameBox { get; set; }

        [xPathsAttributes("//*[@id='vehicle1']")]
        public CheckboxElement BikeCheckbox { get; set; }

        [xPathsAttributes("//*[@id='vehicle2']")]
        public CheckboxElement CarCheckbox { get; set; }

        [xPathsAttributes("//*[@id='vehicle3']")]
        public CheckboxElement BoatCheckbox { get; set; }

        [xPathsAttributes("//*[@onclick='updatedNameText()']")]
        public BasicButtonElement ClickMeButton { get; set; }

        [xPathsAttributes("//div[@id='results']")]
        public DivElement ResultsDiv { get; set; }

        [classNamePathsAttributes("GeneratedTable")]
        public TableCollectionObject TableOne { get; set; }

        [xPathsAttributes("//button[@onclick='addNewRowToTable()']")]
        public BasicButtonElement TableUpdateButton { get; set; }
    }
}
