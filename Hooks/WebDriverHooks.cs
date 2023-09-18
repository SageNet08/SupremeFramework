using Gherkin.Ast;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using TechTalk.SpecFlow;


namespace POMSelenium.Hooks
{
    [Binding]
    public sealed class WebDriverHooks : Browser
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly ScenarioContext _scenarioContext;
      public WebDriverHooks(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("@Chrome")]
        public void BeforeScenarioWithChromeTag()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
          ///  options.AddArgument("--headless");
            driver = new ChromeDriver(options);

        }

        [BeforeScenario("@Firefox")]
        public void BeforeScenarioWithFirefoxTag()
        {

            // FirefoxOptions options = new FirefoxOptions();
            // options.AddArgument("start-maximized");
            

            driver = new FirefoxDriver();

        }

        [BeforeScenario("@Safari")]
        public void BeforeScenarioWithSafariTag()
        {
            driver = new SafariDriver(); 

        }

        [BeforeScenario("@Edge")]
        public void BeforeScenarioWithEdgeTag()
        {
      
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("start-maximized");
            driver = new EdgeDriver();

        }





        [AfterStep("@UI")] 
        
        public void AfterStep() {

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile($"C:\\Users\\P12AE86\\Documents\\UIScreenshots\\/Image_{timestamp}.png",
            ScreenshotImageFormat.Png); 

        }

        [AfterScenario("@UI")]
        public void AfterScenario()
        {

            driver.Quit();
        }

        [AfterStep("@API") ]
        public void AfterAPIStep()
        {
            if(_scenarioContext.TestError != null)
            {
                Console.WriteLine($"Exception occured: { _scenarioContext.TestError}");
            }
        }

    }
}