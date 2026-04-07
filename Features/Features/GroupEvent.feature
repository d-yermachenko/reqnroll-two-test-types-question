Feature: SpendingCreation

Allows to create spending in datatable

Scenario: Create a group event with valid data
	Given I am on the spending creation page
	When I click on the "Create Spending" button
	And I fill in the form with valid data
	| Spending name | Spending Date | Note                    |
	| Test Spending | 2024-06-01    | This is a test spending |
	And I submit the form
	Then I should see a success message
	And the new spending should be listed in the datatable
	
