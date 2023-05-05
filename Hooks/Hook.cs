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
         public async Task<IPage> createBrowser()
                {
                    playwright = await Playwright.CreateAsync();
                    BrowserTypeLaunchOptions typeLaunchOptions = new BrowserTypeLaunchOptions{ Headless = false, Timeout = 60000, Channel = "chromium" };
                    browser = await playwright.Chromium.LaunchAsync(typeLaunchOptions);
                    context = await browser.NewContextAsync();
                    bool enableTracing = false;
                    await context.Tracing.StartAsync(new()
                    {
                        Screenshots = enableTracing,
                        Snapshots = enableTracing,
                        Sources = enableTracing
                    });
                    bool recordVideo = true;
                    if (recordVideo)
                    {
                        var scenarioName = _scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
                        var date = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss");
                        var browserNewPageOptions = new BrowserNewPageOptions
                        {
                            RecordVideoDir = $"../../../videos/{scenarioName}",
                            RecordVideoSize = new RecordVideoSize { Width = 1024, Height = 768 }
                        };
                        page = await browser.NewPageAsync(browserNewPageOptions);
                    }
                    else
                    {
                        page = await browser.NewPageAsync();  
                    }
                    _objectContainer.RegisterInstanceAs(page);
                    return page;
                }
         }
} 