namespace SpecFlowWithPlaywright.PageObjects;

public class UserTablePage
{
    private readonly BasePage.BasePage basePage;
    private readonly Hooks.Hooks _driver;

    public UserTablePage(Hooks.Hooks driver)
    {
        basePage = new BasePage.BasePage(driver.page);
        _driver = driver;
    }

    public async Task AssertUserTable(string txt)
    {
        await basePage.AssertElementToContainText(".smart-table-header-row", txt);
    }

    public async Task AddUser()
    {
        await basePage.ClickAsync("//button[normalize-space()='Add User']");
    }
    public async Task InputFirstName(string txt)
    {
        await basePage.SendTextAsync("input[name='FirstName']", txt);
    }
    public async Task InputLastName(string txt)
    {
        await basePage.SendTextAsync("input[name='LastName']", txt);
    }
    public async Task InputUserName(string txt)
    {
        await basePage.SendTextAsync("input[name='UserName']", txt);
        
    }
    public async Task InputPassword(string txt)
    {
        await basePage.SendTextAsync("input[name='Password']", txt);
        
    }
    public async Task InputEmail(string txt)
    {
        await basePage.SendTextAsync("input[name='Email']", txt);
        
    }
    public async Task InputCellPhone(string txt)
    {
        await basePage.SendTextAsync("input[name='Mobilephone']", txt);
    }
    public async Task SelectRole(string txt)
    {
        await basePage.SelectDropdownOptionAsync("select[name='RoleId']",txt);
    }
    public async Task ClickByText(string txt)
    {
        await basePage.ClickByText(txt);
    }
    public async Task AssertUserNameIsAdded(string txt)
         {
             await basePage.AssertElementToBeVisible($"//td[normalize-space()='{txt}']");
         }
    public async Task AssertUserNameIsNotOntheTable(string txt)
    {
        await basePage.AssertElementNotToContainText("tbody",txt);
    }
    
    public async Task CustomerOption(string txt)
    {
        await basePage.ClickAsync($"//label[normalize-space()='{txt}']");
    }

}
