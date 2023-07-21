namespace SpecFlowWithPlaywright.PageObjects.SaucePages;

public class LoginPage
{
    private readonly BasePage.BasePage basePage;

    public LoginPage(Hooks.Hooks driver)
    {
        basePage = new BasePage.BasePage(driver.page);
    }
 
    public async Task EnterUsername(string username)
    {
        await basePage.GetByPlaceholder("Username",username);
    }
    public async Task EnterPassword(string password)
    {
        await basePage.GetByPlaceholder("Password",password);
    }
    public async Task Button(string Login)
    {
        await basePage.ClickButtonByText(Login);
    }
    
    public async Task AssserPage(string locator, string text)
    {
        await basePage.AssertElementToContainText(locator,text);
    }
}