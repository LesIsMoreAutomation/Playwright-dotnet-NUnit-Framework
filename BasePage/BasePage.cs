using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace SpecFlowWithPlaywright.BasePage
{
    internal class BasePage
    {
        private readonly IPage _page;
       // private MicrosoftLoginPage _microsoftLoginPage;
        public ILocator page { get; }
        public BasePage(IPage page)
        {
            _page = page;
            //_microsoftLoginPage = new MicrosoftLoginPage(_page);
        }


        public void setLocalStoreKeyValue(string strKey, string strValue,Hooks.Hooks driver)
        {
            driver.page.EvaluateAsync(string.Format("localStorage.setItem('{0}', '{1}');", strKey, strValue));
        }

        public void GetToggles(Hooks.Hooks driver)
        {
            setLocalStoreKeyValue("NG_IS_PREPARE_FOR_CREDIT_AND_CAPTURE_AND_VALIDATE", "true",driver);
            setLocalStoreKeyValue("NG_LENDING","true",driver);
            setLocalStoreKeyValue("NG_LENDING_CAPTURE", "true",driver);
            setLocalStoreKeyValue("SHOW_NON_RESIDENTIAL_PRODUCTS", "true",driver);
            setLocalStoreKeyValue("NG_HIDE_INSTALMENT_FIELDS", "true",driver);
            setLocalStoreKeyValue("SHOW_LDF_INITIATE", "true",driver);
            setLocalStoreKeyValue("NG_ENTITY_SEARCH", "true",driver);
            setLocalStoreKeyValue("SHOW_LDF_BASKET", "true",driver);

            

            

       }

       
         public async Task GoToUrl(string url)
        {
            await _page.GotoAsync(url,new() { Timeout = 60000 });
        }

        /// Gets the current URL
        public async Task<string?> GetUrl()
        {
            return _page.Url;
        }

        public async Task<string?> GetValue(string selector)
        {
            return await _page.InnerTextAsync(selector, new() { Timeout = 60000 });
        }

        public async Task SendTextAsync(string selector, string keys, PageFillOptions? pageFillOptions = null)
        {
            await _page.FillAsync(selector, keys, new() { Timeout = 60000 });
        }

        public async Task SendKeystrokesAsync(string selector, string keys, PageTypeOptions? pageTypeOptions = null)
        {
            await _page.TypeAsync(selector, keys, new() { Timeout = 60000 });
        }
        public async Task ClickAsync(string selector)
        {
            await _page.ClickAsync(selector, new() { Timeout = 60000 });
        }
        public async Task FirstElementClickAsync(string selector)
        {
            await _page.Locator(selector).First.ClickAsync();
        }
        public async Task FirstElementByTextClickAsync(string selector)
        {
            await _page.Locator("text=" + selector).First.ClickAsync();
        }
        public async Task VerifyOnboardingDocs(string selector, string text)
        {
            Thread.Sleep(5000);
            try
            {
                int count = await _page.GetByText(text).CountAsync();
                if (count == 1)
                {
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                }
                else if (count == 2)
                {
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                }
                else if (count == 3)
                {
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                }
                else if (count == 4)
                {
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                }
                else if (count == 5)
                {
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                }
                else if (count == 6)
                {
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                    Thread.Sleep(500);
                    await _page.ClickAsync(selector, new() { Timeout = 15000 });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Search for element FAILED");
            }

        }

        public async Task<string?> GetValueAttributeAsync(string selector,
            PageInputValueOptions? pageInputValueOptions = null)
        {
            return await _page.InputValueAsync(selector, new() { Timeout = 60000 });
        }


        public async Task WaitForNonEmptyValue(string selector)
        {
            await _page.WaitForFunctionAsync($"document.querySelector(\"{selector}\").value !== \"\"");
        }

        public async Task WaitForEmptyValue(string selector)
        {
            await _page.WaitForFunctionAsync($"document.querySelector(\"{selector}\").value === \"\"");
        }

        public async Task ReloadPage()
        {
            await _page.ReloadAsync();
        }
        public async Task GetByRole(string role)
        {
            await _page
                .GetByRole(AriaRole.Button, new() {
                    NameRegex = new Regex(role, RegexOptions.IgnoreCase)
                })
                .ClickAsync();
        }
        
        public async Task SelectDropdownOptionAsyncValue(string selector, string value)
        {
            await _page.SelectOptionAsync(selector, new SelectOptionValue { Value = value },
                new() { Timeout = 60000 });
        }

        public async Task SelectDropdownOptionAsyncIndex(string selector, int index)
        {
            await _page.SelectOptionAsync(selector, new SelectOptionValue { Index = index },
                new() { Timeout = 60000 });
        }
        public async Task SelectDropdownOptionAsync(string selector, string label)
        {
            await _page.SelectOptionAsync(selector, new SelectOptionValue { Label = label },
                new() { Timeout = 60000 });
        }

        public async Task SelectDropdownOptionByLabel(string selector, string label,
            PageSelectOptionOptions? pageSelectOptionOptions = null)
        {
            await _page.SelectOptionAsync(selector, new SelectOptionValue { Label = label },
                new() { Timeout = 60000 });
        }

        public async Task GetByPlaceholder(string selector, string val)
        { 
            await _page
                .GetByPlaceholder(selector)
                .FillAsync(val);
        }
        
        public async Task<bool> AssertGetByPlaceholderIsVisibleAsync(string selector)
        {
            await _page.GetByPlaceholder(selector).IsVisibleAsync();
            return false;
        }

        public async Task AssertTargetUrl(string targetUrl)
        {
            await _page.WaitForURLAsync(targetUrl, new() { Timeout = 60000 });
        }

        public async Task ClickByText(string text) =>
            await _page.ClickAsync("text=" + text, new(){Timeout = 60000 });

        public async Task ClickByLabel(string text) =>
            await _page.GetByText("text=" + text).ClickAsync(new() { Timeout = 60000 });

        public async Task WaitTimeOut(string selector)
        {
            await _page.Locator(selector).WaitForAsync(new() { Timeout = 60000 });
        }

        public async Task DocUpload(string doc)
        {
            var fileChooser = await _page.RunAndWaitForFileChooserAsync(async () =>
            {
                await _page.ClickAsync(doc, new() { Timeout = 25000 });
            });
            Console.WriteLine("Intercept fileChooser");
            await fileChooser.SetFilesAsync(@"../../../test.pdf", new() { Timeout = 10000 });
        }
        
        public async Task DragAndDropAsync(string selector)
        {
            await _page.DragAndDropAsync(selector,@"../../../test.pdf");
        }
        [Obsolete("Obsolete")]
        public async Task<bool> CheckElementIsVisible(string selector)
        {
            return await _page.Locator(selector).IsVisibleAsync(new() { Timeout = 60000 });
        }
        public async Task<bool> CheckElementIsNotVisible(string selector)
        {
            return await _page.Locator(selector).IsHiddenAsync(new() { Timeout = 60000 });
        }
        [Obsolete("Obsolete")]
        public async Task<bool> CheckElementIsDisabled(string selector)
        {
            return await _page.Locator(selector).IsDisabledAsync(new() { Timeout = 60000 });
        }
        public async Task<bool> CheckElementIsEnabled(string selector)
        {
            return await _page.Locator(selector).IsEnabledAsync(new() { Timeout = 60000 });
        }
        public async Task AssertElementToHaveText(string selector, string text)
        {
            await Assertions.Expect(_page.Locator(selector)).ToHaveTextAsync(text, new() { Timeout = 60000 });
        }

        public async Task AssertElementNotToBeDisplayed(string selector)
        {
            await Assertions.Expect(_page.Locator(selector)).ToBeHiddenAsync(new() { Timeout = 60000 });
        }

        public async Task AssertElementToBeDisabled(string selector)
        {
            await Assertions.Expect(_page.Locator(selector)).ToBeDisabledAsync(new() { Timeout = 60000 });
        }

        public async Task AssertElementToBeEnabled(string selector)
        {
            await Assertions.Expect(_page.Locator(selector)).ToBeEnabledAsync(new() { Timeout = 60000 });
        }

        public async Task<bool> AssertElementToContainText(string selector, string text)
        {
            await Assertions.Expect(_page.Locator(selector)).ToContainTextAsync(text, new() { Timeout = 60000 });
            return false;
        }
        public async Task<bool> AssertElementNotToContainText(string selector, string text)
        {
            await Assertions.Expect(_page.Locator(selector)).Not.ToContainTextAsync(text, new() { Timeout = 60000 });
            return false;
        }

        public async Task AssertElementToBeEditable(string selector)
        {
            await Assertions.Expect(_page.Locator(selector)).ToBeEditableAsync(new() { Timeout = 60000 });
        }
        public async Task AssertElementToBeVisible(string selector)
        {
            await Assertions.Expect(_page.Locator(selector)).ToBeVisibleAsync(new() { Timeout = 60000 });
        }

        public async Task AssertElementToHaveValue(string selector, string value)
        {
            await Assertions.Expect(_page.Locator(selector)).ToHaveValueAsync(value, new() { Timeout = 60000 });
        }
        public async Task AssertElementToBeCheckedAsync(string selector)
        {
            await Assertions.Expect(_page.Locator(selector)).ToBeCheckedAsync();
        }
     
        public async Task KeyBoard(string text)
        {
            await _page.Keyboard.PressAsync(text);
        }
        public async Task KeyBoardInsertText(string text)
        {
            await _page.Keyboard.InsertTextAsync(text);
        }
        
        public async Task KeyBoardKeyPress(string Option)
        {
            await _page.Keyboard.PressAsync(Option);
            //await _microsoftLoginPage.invLoginSignInBtn.ClickAsync();
           //await _microsoftLoginPage.msStaySignedInBtnYes.CheckAsync();
        }

        public async Task<bool> AssertElementNotToHaveValueAsync(string selector)
        {
            await _page.EvaluateAsync<string>(selector);
            return false;
        }
        public async Task MouseHoverAsync(string selector)
        {
           await _page.HoverAsync(selector);
        }
        
    }
}             
             
             