using BoDi;
using Microsoft.Playwright;

namespace SpecFlowWithPlaywright.Hooks
{
    [Binding]
    public class Hooks
    {
        public static IBrowser browser;
        public IBrowserContext context;
        public IPage page;
        public IPlaywright playwright;
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [AfterScenario()]
        public async Task closeBrowser()
        {
            // Stop tracing and export it into a zip archive.
            await context.Tracing.StopAsync(new()
            {
                Path = $"../../../trace.zip"
            });
            if (_scenarioContext.TestError != null)
            {
                await Helpers.Helpers.Screenshot(page);
            }
            await browser.DisposeAsync();
            
        }

        [BeforeScenario()]
        public async Task createBrowser()
        {
            playwright = await Playwright.CreateAsync();
            BrowserTypeLaunchOptions typeLaunchOptions = new BrowserTypeLaunchOptions{ Headless = false };
            browser = await playwright.Chromium.LaunchAsync(typeLaunchOptions);
            context = await browser.NewContextAsync();
            await context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
            page = await context.NewPageAsync();
            _objectContainer.RegisterInstanceAs(page);
            
        }
    }
}