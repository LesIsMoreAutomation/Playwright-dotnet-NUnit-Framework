namespace SpecFlowWithPlaywright.PageObjects;

public class SignInPage
{
    
    
    
    private readonly BasePage.BasePage basePage;
    private readonly Hooks.Hooks _driver;

    public SignInPage(Hooks.Hooks driver)
    {
        basePage = new BasePage.BasePage(driver.page);
        _driver = driver;
    }
   

      
        public async Task AssertWelcomeBack(string txt)
        {
            await basePage.AssertElementToHaveText("main#main-content article > h2",txt);
        }
        public async Task EnterEmail(string email)
        {
            await basePage.GetByPlaceholder("Email",email);
        }
        public async Task EnterPassword(string password)
        {
            await basePage.GetByPlaceholder("Password",password);
        }
        public async Task SignInButton()
        {
            await basePage.ClickAsync("//button[normalize-space()='Sign in']");
        }
        
}