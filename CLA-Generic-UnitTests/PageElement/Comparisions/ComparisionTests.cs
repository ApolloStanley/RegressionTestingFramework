using CLA_Generic_AUT.PageElement;
using CLA_Generic_AUT.PageElement.Tables;
using CLA_Generic_AUT.PageElement.Tables.Comparision;
using CLA_Generic_AUT.WebHandler;
using Moq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_UnitTests.PageElement.Comparisions
{
    public class ComparisionTests
    {
        [Theory]
        [InlineData("test", "test", true)]
        [InlineData("test", "Test", true)]
        [InlineData("test", "Test1", false)]
        [InlineData("test1", "Test", false)]
        public void GivenTwoCells_ComparesIfTheyAreEqual_ReturnsExpectedValue(string cellOneValue, string cellTwoValue, bool expectedOutCome)
        {
            var newMockOne = new Mock<IWebElement>();
            newMockOne.Setup(x => x.Text).Returns(cellOneValue);

            var newMockTwo = new Mock<IWebElement>();
            newMockTwo.Setup(x => x.Text).Returns(cellTwoValue);

            var cellOne = new TableCell(newMockOne.Object);
            var cellTwo = new TableCell(newMockTwo.Object);

            Assert.Equal(expectedOutCome, new TableCellComparer().Equals(cellOne, cellTwo));
        }

        [Theory]
        [InlineData("test", "test", true)]
        [InlineData("Test", "Test", true)]
        [InlineData("test", "Test", false)]
        [InlineData("test", "Test1", false)]
        [InlineData("test1", "Test", false)]
        public void GivenTwoCells_CompareCaseSensititiveIfTheyAreEqual_ReturnsExpectedValue(string cellOneValue, string cellTwoValue, bool expectedOutCome)
        {
            var newMockOne = new Mock<IWebElement>();
            newMockOne.Setup(x => x.Text).Returns(cellOneValue);

            var newMockTwo = new Mock<IWebElement>();
            newMockTwo.Setup(x => x.Text).Returns(cellTwoValue);

            var cellOne = new TableCell(newMockOne.Object);
            var cellTwo = new TableCell(newMockTwo.Object);

            Assert.Equal(expectedOutCome, new TableCellCaseSensitiveComparer().Equals(cellOne, cellTwo));
        }

        [Theory]
        [InlineData(new string[] { "valueOne", "valueTwo", "valueThree" }, new string[] { "valueOne", "valueTwo", "valueThree" }, true )]
        [InlineData(new string[] { "valueOneX", "valueTwo", "valueThree" }, new string[] { "valueOne", "valueTwo", "valueThree" }, false)]
        [InlineData(new string[] { "valueOne", "valueTwoX", "valueThree" }, new string[] { "valueOne", "valueTwo", "valueThree" }, false)]
        [InlineData(new string[] { "valueOne", "valueTwo", "valueThreeX" }, new string[] { "valueOne", "valueTwo", "valueThree" }, false)]
        [InlineData(new string[] { "valueOne", "valueTwo", "valueThree" }, new string[] { "valueOneX", "valueTwo", "valueThree" }, false)]
        [InlineData(new string[] { "valueOne", "valueTwo", "valueThree" }, new string[] { "valueOne", "valueTwoX", "valueThree" }, false)]
        [InlineData(new string[] { "valueOne", "valueTwo", "valueThree" }, new string[] { "valueOne", "valueTwo", "valueThreeX" }, false)]
        public void GivenTwoRowsOfEqualSize_ComparesIfTheyHaveTheSameVAlues_ReturnsExpected(string[] rowOneValue, string[] rowTwoValue, bool expectedValue)
        {
            var rowComparer = new TableRowComparer();

            var rowOne = CreateRowFromArray(rowOneValue);
            var rowTwo = CreateRowFromArray(rowTwoValue);

            Assert.Equal(expectedValue, rowComparer.Equals(rowOne, rowTwo));

        }

        [Theory]
        [InlineData(new string[] { "valueOne", "valueTwo", "valueThree" }, new string[] { "valueOne", "valueTwo", "valueThree" }, true)]
        [InlineData(new string[] { "valueOne", "valueTwo", "valueThree" }, new string[] { "valueOne", "valueTwo" }, false)]
        [InlineData(new string[] { "valueOne", "valueTwo"  }, new string[] { "valueOne", "valueTwo", "valueThree" }, false)]
        [InlineData(new string[] { "valueOne", "valueTwo" }, new string[] { "valueOne", "valueTwo" }, true)]

        public void GivenTwoRowsOfDifferentSizes_ComparesIfTheyHaveTheSameVAlues_ReturnsExpected(string[] rowOneValue, string[] rowTwoValue, bool expectedValue)
        {
            var rowComparer = new TableRowComparer();

            var rowOne = CreateRowFromArray(rowOneValue);
            var rowTwo = CreateRowFromArray(rowTwoValue);

            Assert.Equal(expectedValue, rowComparer.Equals(rowOne, rowTwo));

        }

        [Fact]
        public void GivenTwoIdenticalTables_WhenCompared_ReturnsTrue()
        {
            var tableValues = new List<string[]>()
            {
                new string[] { "R1C1", "R1C2", "R1C3" },
                new string[] { "R2C1", "R2C2", "R2C3" },
                new string[] { "R3C1", "R3C2", "R3C3" }
            };

            var bodyOne = CreateTable(tableValues);
            var bodyTwo = CreateTable(tableValues);

            var comparer = new TableBodyComparer();

            Assert.True(comparer.ContainsSameRows(bodyOne, bodyTwo));
            Assert.True(comparer.ContainsSameRowsInOrder(bodyOne, bodyTwo));
        }

        [Fact]
        public void GivenTwoNoneIdenticalTables_WhenCompared_ReturnsFalsee()
        {
            var tableValues = new List<string[]>()
            {
                new string[] { "R1C1", "R1C2", "R1C3" },
                new string[] { "R2C1", "R2C2", "R2C3" },
                new string[] { "R3C1", "R3C2", "R3C3" }
            };

            var tableValuesTwo = new List<string[]>()
            {
                new string[] { "R1C1", "R1C2", "R1C3" },
                new string[] { "R2C1", "R2C2", "R2CX" },
                new string[] { "R3C1", "R3C2", "R3C3" }
            };

            var bodyOne = CreateTable(tableValues);
            var bodyTwo = CreateTable(tableValuesTwo);

            var comparer = new TableBodyComparer();

            Assert.False(comparer.ContainsSameRows(bodyOne, bodyTwo));
            Assert.False(comparer.ContainsSameRowsInOrder(bodyOne, bodyTwo));

            var difRows = comparer.FindRowsDifferentInTableTwo(bodyOne, bodyTwo);

            Assert.Single(difRows);
            Assert.Contains(difRows, x => x.TableRowCells[2].Text == "R2CX");
        }

        [Fact]
        public void GivenTwoRowsWhereOneIsNume_ComparesIfTheyHaveTheSameVAlues_ReturnsExpected()
        {
            var rowComparer = new TableRowComparer();

            var rowOne = CreateRowFromArray(new string[] { "valueOne", "valueTwo", "valueThree" });

            Assert.False(rowComparer.Equals(rowOne, null));
            Assert.False(rowComparer.Equals(null, rowOne));
            Assert.False(rowComparer.Equals(null, null));
        }

        private TableBody CreateTable(List<string[]> tableValues)
        {
            var newMock = new Mock<IWebElement>();
            newMock.Setup(x => x.FindElements(It.IsAny<By>())).Returns<ReadOnlyCollection<IWebElement>>(null);

            var newBody = new TableBody(newMock.Object);
            newBody.TableRows = new List<TableRow>();

            foreach (var rowValues in tableValues)
            {
                newBody.TableRows.Add((TableRow)CreateRowFromArray(rowValues));
            }

            return newBody;
        }

        private ITableRow CreateRowFromArray(string[] arrayValue)
        {
            var cells = arrayValue?.Select(x => CreateCellFromValue(x));

            var newMock = new Mock<IWebElement>();
            newMock.Setup(x => x.FindElements(It.IsAny<By>())).Returns<ReadOnlyCollection<IWebElement>>(null);

            var newRow = new TableRow(newMock.Object);
            newRow.TableRowCells = cells?.ToList();

            return newRow;
        }

        private TableCell CreateCellFromValue(string value)
        {
            var newMock = new Mock<IWebElement>();
            newMock.Setup(x => x.Text).Returns(value);

            return new TableCell(newMock.Object);
        }
    }
}
