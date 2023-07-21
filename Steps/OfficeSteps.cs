
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecFlowWithPlaywright.PageObjects;
using SpecFlowWithPlaywright.PageObjects.SaucePages;
using TechTalk.SpecFlow;

namespace SpecFlowWithPlaywright.Steps;

[Binding]
public class OfficeSteps

{
    private static CommonPageObjects _common;
    private readonly LoginPage _loginPage;
    private readonly ProductsPage _productsPage;
    

    public OfficeSteps(Hooks.Hooks driver)
    {
        _common = new CommonPageObjects(driver);
        _loginPage = new LoginPage(driver);
        _productsPage = new ProductsPage(driver);
    }


    [Given(@"I navigate to ""(.*)""")]
    public async Task GivenINavigateTo(string url)
    {
        await _common.GivenINavigateTo(url);
    }

    [When(@"enter ""(.*)"" input data on the ""(.*)""")]
    public async Task WhenEnterInputData(string p0,string p1)
    {
        await _common.EnterInputField(p0,p1);
    }

    
}