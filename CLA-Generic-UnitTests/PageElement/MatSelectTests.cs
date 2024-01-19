using CLA_Generic_AUT.PageElement.Tables;
using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Collections.ObjectModel;
using CLA_Generic_AUT.PageElement.Select;
using CLA_Generic_AUT.PageElement.Select.MatSelect.MatMultiSelect;
using CLA_Generic_AUT.PageElement.Select.MatSelect;

namespace CLA_Generic_UnitTests.PageElement
{
    public class MatSelectTests
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
            var matOptions = MockSelect().OpenMenu();

            Assert.NotNull(matOptions);
            Assert.Equal(4, matOptions.Count());
        }

        [Fact]
        public void SelectElement_GivenAnIndexElement_IndexOptionIsClicked()
        {
            var matElements = MockSelect();

            var matOptions = matElements.OpenMenu();

            matElements.SelectByIndex(2);

            Assert.Single(matOptions.Where(x => x.OptionIsSelected));
            Assert.Equal("TestTwo", matOptions.Where(x => x.OptionIsSelected).First().Text);   
        }

        [Fact]
        public void SelectElements_GivenMultipleIndexElements_IndexOptionsAreClicked()
        {
            List<int> multiOptions = new List<int> { 2, 3 };

            var matElements = MockMultiSelect();

            var matOptions = matElements.OpenMenu();

            matElements.SelectMultiple(multiOptions);

            Assert.Equal(2, matOptions.Where(x => x.OptionIsSelected).Count());
            Assert.Contains(matOptions, x  => x.OptionIsSelected && x.Text == "TestTwo");
            Assert.Contains(matOptions, x => x.OptionIsSelected && x.Text == "TestThree");
        }

        private MatMultiSelect MockMultiSelect()
        {
            var mockIWebHandler = new Mock<IWebHandler>();
            mockIWebHandler.Setup(x => x.HandlerConfig).Returns(new WebHandlerConfig());

            var mockMatMultiSelectWebElement = new Mock<IWebElement>();
            mockIWebHandler.Setup(x => x.GetElement(It.IsAny<By>())).Returns(mockMatMultiSelectWebElement.Object);

            var mockOptions = new List<Mock<IWebElement>>()
            {
                createOption("TestOne",false),
                createOption("TestTwo",false),
                createOption("TestThree",false),
                createOption("TestFour",false)
            };

            var mockCollection = new ReadOnlyCollection<IWebElement>(mockOptions.Select(z => z.Object).ToList());

            mockIWebHandler.Setup(x => x.GetElements(It.IsAny<By>())).Returns(mockCollection);

            return new MatMultiSelect(By.Id(""), mockIWebHandler.Object);
        }

        private MatSelect MockSelect()
        {
            var mockIWebHandler = new Mock<IWebHandler>();
            mockIWebHandler.Setup(x => x.HandlerConfig).Returns(new WebHandlerConfig());


            var mockMatSelectWebElement = new Mock<IWebElement>();
            mockIWebHandler.Setup(x => x.GetElement(It.IsAny<By>())).Returns(mockMatSelectWebElement.Object);

            var mockOptions = new List<Mock<IWebElement>>()
            {
                createOption("TestOne",false),
                createOption("TestTwo",false),
                createOption("TestThree",false),
                createOption("TestFour",false)
            };

            var mockCollection = new ReadOnlyCollection<IWebElement>(mockOptions.Select(z => z.Object).ToList());

            mockIWebHandler.Setup(x => x.GetElements(It.IsAny<By>())).Returns(mockCollection);

           return new MatSelect(By.Id(""), mockIWebHandler.Object);
        }

        private Mock<IWebElement> createOption(String optionValue, bool isSelected) 
        {
            var mockOption = new Mock<IWebElement>();

            mockOption.Setup(x => x.GetAttribute(It.IsAny<string>())).Returns(isSelected.ToString());

            mockOption.Setup(x => x.Text).Returns(optionValue);

            mockOption.Setup(x => x.Click());

            return mockOption;
        }

    }
}
