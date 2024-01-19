using CLA_Generic_AUT.PageElement;
using CLA_Generic_AUT.WebHandler.Config;
using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecflowTemplate;
using CLA_Generic_AUT.PageElement.Tables;

namespace CLA_Generic_UnitTests.PageElement
{
    public class TableElementsTest
    {

        private IWebHandler GetWebHandler()
        {
            var myFactory = new WebHandlerFactory();

            var config = WebHandlerConfigMapper.GetWebHandlerConfig();

            return myFactory.CreateHandler(config);
        }

        [Fact]
        public void TableElement_GivenATableElement_TableElementLoads()
        {
            using (var webHandler = GetWebHandler())
            {
                webHandler.Navigate(TestData.basicPageAddress);

                var Table = new TableCollectionObject(By.XPath("//*[@class=\"GeneratedTable\"]"), webHandler, new TimeSpan(0, 0, 20));


                Assert.NotNull(Table);
                Assert.Equal("RowOneCellOne", Table[1, 1].Text);
                Assert.Equal("RowTwoCellOne", Table[2, "HeaderOne"].Text);
                Assert.Equal("HeaderOne", Table.TableHeader[1].Text);

            }
        }
    }
}
