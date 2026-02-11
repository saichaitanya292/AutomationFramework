using Microsoft.Playwright;
using TestProject1.Utilities;

namespace TestProject1.Drivers
{
    public class PlaywrightDriver
    {
        public IPlaywright Playwright { get; private set; } = null!;
        public IBrowser Browser { get; private set; } = null!;
        public IBrowserContext Context { get; private set; } = null!;
        public IPage Page { get; private set; } = null!;

        public async Task InitializeAsync()
        {
      
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

           
            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = ConfigReader.Headless
            };

          
            Browser = ConfigReader.Browser switch
            {
                "Firefox" => await Playwright.Firefox.LaunchAsync(launchOptions),
                "Webkit" => await Playwright.Webkit.LaunchAsync(launchOptions),
                _ => await Playwright.Chromium.LaunchAsync(launchOptions)
            };

            
            Context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                },
                DeviceScaleFactor = 1   
            });

         
            Page = await Context.NewPageAsync();
        }

        public async Task QuitAsync()
        {
            if (Context != null)
                await Context.CloseAsync();

            if (Browser != null)
                await Browser.CloseAsync();

            Playwright?.Dispose();
        }
    }
}
