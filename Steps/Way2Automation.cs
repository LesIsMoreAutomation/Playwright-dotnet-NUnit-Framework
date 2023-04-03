using SpecFlowWithPlaywright.PageObjects;

namespace SpecFlowWithPlaywright.Steps;

[Binding]
public class Way2Automation
{
    
    private static CommonPageObjects _common;
    public string uniqueUserName1;
    private readonly UserTablePage _userTablePage;
    

    public Way2Automation(Hooks.Hooks driver)
    {
        _common = new CommonPageObjects(driver);
        _userTablePage = new UserTablePage(driver);
    }

    [Given(@"Navigate to (.*)")]
    public async Task GivenNavigateTo(string url)
    {
        await _common.GivenINavigateTo(url);
    }

    [Given(@"Validate that you are on the User List Table")]
    public async Task GivenValidateThatYouAreOnTheUserListTable()
    {
        await _userTablePage.AssertUserTable("First Name");
        await _userTablePage.AssertUserTable("Last Name");
        await _userTablePage.AssertUserTable("User Name");
    }

    [When(@"I Click Add user")]
    public async Task WhenIClickAddUser()
    {
        await _userTablePage.AddUser();
    }

    [When(@"populate First Name (.*)")]
    public async Task WhenPopulate(string p0)
    {
        await _userTablePage.InputFirstName(p0);
    }

    [When(@"populate Last Name (.*)")]
    public async Task WhenPopulateLastName(string p0)
    {
        await _userTablePage.InputLastName(p0);
    }

    [When(@"populate User Name (.*)")]
    public async Task  WhenPopulateUserName(string p0)
    {
        uniqueUserName1 = p0;
        await _userTablePage.InputUserName(uniqueUserName1);
    }

    [When(@"populate Password (.*)")]
    public async Task  WhenPopulatePassword(string password)
    {
        await _userTablePage.InputPassword(password);
    }

    [When(@"click Customer option as (.*)")]
    public async Task  WhenClickCustomerOptionAs(string customer)
    {
        await _userTablePage.CustomerOption(customer);
    }

    [When(@"select role on the options (.*)")]
    public async Task  WhenSelectRoleFromTheDropdownList(string role)
    {
        await _userTablePage.SelectRole(role);
    }

    [When(@"populate E-mail (.*)")]
    public async Task  WhenPopulateEMail(string p0)
    {
        await _userTablePage.InputEmail(p0);
    }

    [When(@"populate Cell Phone (.*)")]
    public async Task  WhenPopulateCellPhone(string cell)
    {
        await _userTablePage.InputCellPhone(cell);
    }

    [Then(@"Ensure that your users are added to the list")]
    public async Task ThenEnsureThatYourUsersAreAddedToTheList()
    {
        await _userTablePage.AssertUserNameIsAdded(uniqueUserName1);
    }

    [Then(@"click on ""(.*)""")]
    public async Task ThenClickOn(string save)
    {
        await _userTablePage.ClickByText(save);
    }

    [Given(@"Ensure that User Name (.*) is unique on each run")]
    public async Task GivenEnsureThatUserNameIsUniqueOnEachRun(string p0)
    {
        await _userTablePage.AssertUserNameIsNotOntheTable(p0);
    }
}