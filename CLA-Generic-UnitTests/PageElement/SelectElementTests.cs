using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLA_Generic_AUT.PageElement.Select.MatSelect.MatMultiSelect;
using CLA_Generic_AUT.PageElement.Select.MatSelect;
using Moq;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using CLA_Generic_AUT.PageElement.Select.DefaultSelect;

namespace CLA_Generic_UnitTests.PageElement
{
    public class SelectElementTests
    {
        private IWebHandler GetWebHandler()
        {
            var myFactory = new WebHandlerFactory();

            var config = WebHandlerConfigMapper.GetWebHandlerConfig();

            return myFactory.CreateHandler(config);
        }

        [Fact]
        public void SelectElement_GivenASelectElement_LoadsAllOptions()
        {
            var selectOptions = MockSelect().OpenMenu();

            Assert.NotNull(selectOptions);
            Assert.Equal(4, selectOptions.Count());
        }

        [Fact]
        public void SelectElement_GivenAnIndexElement_IndexOptionIsClicked()
        {
            var selectElement = MockSelect();

            var selectOptions = selectElement.OpenMenu();

            selectElement.SelectByIndex(2);

            Assert.Single(selectOptions.Where(x => x.OptionIsSelected));
            Assert.Equal("TestTwo", selectOptions.Where(x => x.OptionIsSelected).First().Text);
        }

        private Select MockSelect()
        {
            var mockIWebHandler = new Mock<IWebHandler>();
            mockIWebHandler.Setup(x => x.HandlerConfig).Returns(new WebHandlerConfig());

            var mockSelectWebElement = new Mock<IWebElement>();
            mockIWebHandler.Setup(x => x.GetElement(It.IsAny<By>())).Returns(mockSelectWebElement.Object);

            var mockOptions = new List<Mock<IWebElement>>()
            {
                createOption("TestOne",false),
                createOption("TestTwo",false),
                createOption("TestThree",false),
                createOption("TestFour",false)
            };

            var mockCollection = new ReadOnlyCollection<IWebElement>(mockOptions.Select(z => z.Object).ToList());

            mockIWebHandler.Setup(x => x.GetElements(It.IsAny<By>())).Returns(mockCollection);

            return new Select(By.Id(""), mockIWebHandler.Object);
        }

        private Mock<IWebElement> createOption(string optionValue, bool isSelected)
        {
            var mockOption = new Mock<IWebElement>();

            mockOption.Setup(x => x.GetAttribute(It.IsAny<string>())).Returns(isSelected.ToString());

            mockOption.Setup(x => x.Text).Returns(optionValue);

            mockOption.Setup(x => x.Click());

            return mockOption;
        }


    }
}
