using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecFlowWithPlaywright.PageObjects;
using SpecFlowWithPlaywright.PageObjects.SaucePages;
using TechTalk.SpecFlow;

namespace SpecFlowWithPlaywright.Steps;

[Binding]
public sealed class SauceLabs
{
    private static CommonPageObjects _common;
    private readonly LoginPage _loginPage;
    private readonly ProductsPage _productsPage;
    

    public SauceLabs(Hooks.Hooks driver)
    {
        _common = new CommonPageObjects(driver);
        _loginPage = new LoginPage(driver);
        _productsPage = new ProductsPage(driver);
    }


    [Given(@"I am on the SauceDemo login page")]
    public async Task GivenIAmOnTheSauceDemoLoginPage()
    {
        await _common.GivenINavigateTo("https://www.saucedemo.com/");
    }
    

    [Then(@"the user should be successfully logged in")]
    public async Task ThenTheUserShouldBeSuccessfullyLoggedIn()
    {
        await _loginPage.AssserPage(".app_logo","Swag Labs");
    }

    [When(@"I login with a valid ""(.*)"" and ""(.*)""")]
    public async Task WhenILoginWithAValidAnd(string username, string password)
    {
        await _loginPage.EnterUsername(username);
        await _loginPage.EnterPassword(password);
    }

    [When(@"click on the ""(.*)"" button")]
    public async Task WhenClickOnTheLoginButton(string Login)
    {
        await _loginPage.Button(Login);
    }

    [Then(@"the user should not login successfully")]
    public async Task ThenTheUserShouldNotLoginSuccessfully()
    {
        await _loginPage.AssserPage(".error-message-container.error","Epic sadface: Sorry, this user has been locked out.");
    }

    [When(@"I filter items ""(.*)"" by pricing")]
    public async Task WhenIFilterItemsByPricing(string p0)
    {
        await _productsPage.filterProducts(p0);
    }

    [Then(@"the user should see the first item is the lowest and the last item is the highest in price")]
    public async Task ThenTheUserShouldSeeTheFirstItemIsTheLowestAndTheLastItemIsTheHighestInPrice()
    {
        await _productsPage.VerifyLowestHigh();
    }

    [When(@"I add (.*) items to the cart")]
    public async Task WhenIAddItemsToTheCart(int p0)
    {
        for (int i = 0; i < p0; i++)
        {
            await _productsPage.ClickByText("Add to cart");
        }
    }

    [Then(@"the user should see (.*) items in the cart")]
    public async Task ThenTheUserShouldSeeItemsInTheCart(string p0)
    {
        await _productsPage.AssertShoppingCart(p0);
    }
}