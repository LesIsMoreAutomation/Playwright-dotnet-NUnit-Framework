using SpecFlowWithPlaywright.PageObjects;

namespace SpecFlowWithPlaywright.Steps;



[Binding]
public class CommonStep
{
    private static CommonPageObjects _common;
 
    private readonly SignInPage _signInPage;
    

    public CommonStep(Hooks.Hooks driver)
    {
        _common = new CommonPageObjects(driver);
        _signInPage = new SignInPage(driver);
        
    }

    [Given(@"I navigate to ultimate automation website (.*)")]
    public async Task GivenINavigateToUltimateAutomation(string env)
    {
        await _common.GivenINavigateTo(
            
            $"https://courses.ultimate{env}.com/users/sign_in");
    }

    [Then(@"assert sign in page has header ""(.*)""")]
    public async Task ThenAssertSignInPageHasHeader(string p0)
    {
        await _signInPage.AssertWelcomeBack(p0);
    }

    [When(@"I enter email ""(.*)""")]
    public  async Task WhenIEnterEmail(string p0)
    {
        await _signInPage.EnterEmail(p0);
    }

    [When(@"I enter paasword ""(.*)""")]
    public  async Task WhenIEnterPaasword(string p0)
    {
        await _signInPage.EnterPassword(p0);
    }

    [Then(@"I click on the sign in button")]
    public  async Task ThenIClickOnTheSignInButton()
    {
        await _signInPage.SignInButton();
    }
}