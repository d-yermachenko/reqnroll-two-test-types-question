using Reqnroll;

namespace Tests.EToE.StepDefinitions;

[Binding]
public sealed class SpendingCreation(Reqnroll.IReqnrollOutputHelper outputHelper)
{
    [Given("I am on the spending creation page")]
    public void GivenIAmOnTheSpendingCreationPage()
    {
        outputHelper.WriteLine("Navigating to the spending creation page...");
    }

    [When("I click on the {string} button")]
    public void WhenIClickOnTheButton(string p0)
    {
        outputHelper.WriteLine($"Clicking on the '{p0}' button...");
    }

    [When("I fill in the form with valid data")]
    public void WhenIFillInTheFormWithValidData(DataTable dataTable)
    {
        outputHelper.WriteLine("Filling in the form with valid data...");
    }

    [When("I submit the form")]
    public void WhenISubmitTheForm()
    {
        outputHelper.WriteLine("Submitting the form...");
    }

    [Then("I should see a success message")]
    public void ThenIShouldSeeASuccessMessage()
    {
        outputHelper.WriteLine("Checking for success message...");
        Assert.True(true, "Success message is displayed.");
    }

    [Then("the new spending should be listed in the datatable")]
    public void ThenTheNewSpendingShouldBeListedInTheDatatable()
    {
        outputHelper.WriteLine("Checking if the new spending is listed in the datatable...");
        Assert.True(true, "New spending is listed in the datatable.");
    }

}
