using CLA_Generic_AUT.PageElement.CustomePageElements;
using CLA_Generic_AUT.PageElement.Select;
using CLA_Generic_AUT.WebHandler;
using CLA_Generic_AUT.WebHandler.Config;
using Moq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_UnitTests.PageElement
{
    public class MetaDataElementTests
    {

        [Fact]
        public void MetaDataCards_GivenAMatCard_HeaderCanBeReturned()
        {
            var MatCardHeader = GetMetaDataCards("Test Header").HeaderTitle;
            Assert.Equal("Test Header", MatCardHeader.Text);

        }


        private IMetaDataCards GetMetaDataCards(String header) 
        {
            var element = new Mock<IWebElement>();
            element.Setup(x => x.Text).Returns(header);

            var mockIMatCard = new Mock<IMetaDataCards>();

            mockIMatCard.Setup(ManifestationCard => ManifestationCard.HeaderTitle).Returns(new CLA_Generic_AUT.PageElement.InlineStaticElements.DivElement(element.Object));

            return mockIMatCard.Object;
        }

       
    }
}
