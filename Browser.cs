using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace POMSelenium
{
    public class Browser
    {



        public static IWebDriver driver { get; set; }
        public string baseUrl = "https://localhost:44315/";
       

        //public  ChromeDriver ChromeBrowser(IWebDriver driver ) 
      //  { 
        
       // this.driver = driver;
       // return  new ChromeDriver() { }; 
        
       // }
    


        public void goToThisUrl(IWebDriver driver )
        {
           driver.Navigate().GoToUrl(baseUrl);
        }


        public void Kill()
        {

            driver.Close(); 
        }


        public string Title(IWebDriver driver)
        {
            return driver.Title; 
        }

    }
}
