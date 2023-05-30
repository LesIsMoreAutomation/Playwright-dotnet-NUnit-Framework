using NUnit.Framework;

namespace SpecFlowWithPlaywright.PageObjects.SaucePages;

public class ProductsPage
{
    private readonly BasePage.BasePage basePage;

    public ProductsPage(Hooks.Hooks driver)
    {
        basePage = new BasePage.BasePage(driver.page);
    }
    
    public async Task filterProducts(string text)
    {
        await basePage.SelectDropdownOptionByLabel(".product_sort_container",text);
    }
    public async Task VerifyLowestHigh()
    {
        // Get the prices of all items
        var prices = await basePage.GetAllValues(".inventory_item_price");

        // Remove the dollar sign and convert prices to decimal
        var trimmedPrices = prices.Select(price => decimal.Parse(price.Trim('$'))).ToList();

        // Iterate through the prices and assert order
        for (int i = 0; i < trimmedPrices.Count - 1; i++)
        {
            Console.WriteLine(trimmedPrices[i]);
            Assert.LessOrEqual(trimmedPrices[i], trimmedPrices[i + 1], $"Price at index {i} is not less than or equal to the price at index {i + 1}.");
        }
    }

    public async Task ClickByText(string text)
    {
        await basePage.FirstElementByTextClickAsync(text);
    }
    
    public async Task AssertShoppingCart(string text)
    {
        await basePage.AssertElementToContainText(".shopping_cart_badge",text);
    }
    
}