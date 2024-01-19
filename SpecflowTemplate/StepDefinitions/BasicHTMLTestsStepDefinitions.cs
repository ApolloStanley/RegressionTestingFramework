using CLA_Generic_AUT.PageElement.Tables;
using CLA_Generic_AUT.PageElement.Tables.Comparision;
using CLA_Generic_AUT.PageObjects;
using SpecflowTemplate.ExamplePageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTemplate.StepDefinitions
{
    [Binding]
    public class BasicHTMLTestsStepDefinitions: ClaBaseSpecFlowStepDef
    {
        TestPageObject MyPage;

        [Given(@"We navigat to test page")]
        public void GivenWeNavigatToTestPage()
        {
            MyPage = PageObjectLoader<TestPageObject>.LoadPageObject(WebHandler, TestData.basicPageAddress) as TestPageObject;            
        }


        [Given(@"We have entered a (.*) into the first name input box")]
        public void GivenWeHaveEnteredAFooIntoTheFirstNameInputBox(string name)
        {
            MyPage.FirstNameBox.SetText(name);
        }

        [Given(@"We have entered a (.*) into the last name input box")]
        public void GivenWeHaveEnteredABarIntoTheLastNameInputBox(string name)
        {
            MyPage.SecondNameBox.SetText(name);
        }

        [When(@"I click the click me button")]
        public void WhenIClickTheClickMeButton()
        {
            MyPage.ClickMeButton.ClickButton();
        }

        [Then(@"the text reads (.*)")]
        public void ThenTheTextReadsFooBar(string name1)
        {
            Assert.Equal(name1, MyPage.ResultsDiv.Text);
        }

        TableBody bodyOne, bodyTwo;

       [Given(@"I have viewed table one")]
        public void GivenIHaveViewedTableOne()
        {
            bodyOne = MyPage.TableOne.TableBody;
        }

        [When(@"I click a table populater button")]
        public void WhenIClickATablePopulaterButton()
        {
            MyPage.TableUpdateButton.ClickButton();
        }

        [Then(@"When I check this tale the values will be different")]
        public void ThenWhenICheckThisTaleTheValuesWillBeDifferent()
        {
            // Reload the page
            // compare to the new table
            Thread.Sleep(1000);
            PageObjectLoader<TestPageObject>.LoadElements(MyPage, WebHandler);
            Thread.Sleep(1000);
            
            bodyTwo = MyPage.TableOne.TableBody;

            var tableBodyComparer = new TableBodyComparer();
            var difRows = tableBodyComparer.FindRowsDifferentInTableTwo(bodyOne, bodyTwo);

            Assert.False(tableBodyComparer.ContainsSameRows(bodyOne, bodyTwo));
            Assert.Single(difRows);
            Assert.Contains(difRows, x => x.TableRowCells[0].Text == "NEW CELL1");
            Assert.Contains(difRows, x => x.TableRowCells[1].Text == "NEW CELL2");
            Assert.Contains(difRows, x => x.TableRowCells[2].Text == "NEW CELL3");

        }

    }
}
