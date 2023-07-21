namespace SpecFlowWithPlaywright.PageObjects
{
    public class CommonPageObjects
    {
        private readonly BasePage.BasePage basePage;

        public CommonPageObjects(Hooks.Hooks driver)
        {
            basePage = new BasePage.BasePage(driver.page);
        }

        public async Task GivenINavigateTo(string p0)
        {
            await basePage.GoToUrl(p0);
        }

        public async Task EnterInputField(string username,string locator)
        {
            await basePage.GetByPlaceholder(locator,username);
        }
        
        
    }
}