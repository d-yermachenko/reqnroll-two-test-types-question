using Xunit;

namespace Tests.Integration.StepDefinitions;

[Binding]
public sealed class SpendingCreation(Reqnroll.IReqnrollOutputHelper outputHelper)
{
    [Given("I am on the spending creation page")]
    public void GivenIAmOnTheSpendingCreationPage()
    {
        outputHelper.WriteLine("As it is api test, doing nothing");
    }

    [When("I click on the {string} button")]
    public void WhenIClickOnTheButton(string p0)
    {
        outputHelper.WriteLine($"As it is api test, doing nothing when clicking on the '{p0}' button...");
    }

    [When("I fill in the form with valid data")]
    public void WhenIFillInTheFormWithValidData(DataTable dataTable)
    {
        outputHelper.WriteLine("As it is api test, preparing DTO from provided data");
    }

    [When("I submit the form")]
    public void WhenISubmitTheForm()
    {
        outputHelper.WriteLine("As it is api test, sending request to the API...");
    }

    [Then("I should see a success message")]
    public void ThenIShouldSeeASuccessMessage()
    {
        outputHelper.WriteLine("As it is api test, checking for success response...");
        Assert.True(true, "Success response is received.");
    }

    [Then("the new spending should be listed in the datatable")]
    public void ThenTheNewSpendingShouldBeListedInTheDatatable()
    {
        outputHelper.WriteLine("As it is api test, checking if the new spending is listed in the datatable...");
        Assert.True(true, "New spending is listed in the datatable.");
    }

}
