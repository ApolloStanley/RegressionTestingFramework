Feature: Basic HTML tests

A short summary of the feature

@tag1
Scenario: Button click sample
	Given We navigat to test page
	Given We have entered a foo into the first name input box
	Given We have entered a bar into the last name input box
	When I click the click me button
	Then the text reads foo bar


@tag2
Scenario: Table comparison example
	Given We navigat to test page
	Given I have viewed table one
	When I click a table populater button
	Then When I check this tale the values will be different