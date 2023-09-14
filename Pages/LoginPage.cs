using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMSelenium.Pages
{
    public class LoginPage
    {

        
         public IWebDriver driver  { get; set; }
        public LoginPage(IWebDriver driver){ this.driver = driver; PageFactory.InitElements(driver, this);  }



        By email = By.Id("Input_Email");
        By password = By.Id("Input_Password");
        public By lgnpagename = By.TagName("h2");
        public By lgnbtn = By.XPath("//a[contains(text(), 'Login')]");
        public By lgnname = By.XPath("//button[contains(text(), 'Log in')]");
        public By invalidText = By.XPath("//ul/li");
        


        public IWebElement GetElement(string username)
        {
             return driver.FindElement(By.XPath(username));

        }

        public string XpathBuilder(string upperLeftUsername)
        {
            string a = "//div[contains(text(), \"";

            string b = "\")]";

            string fullPath = a + upperLeftUsername + b;
            return fullPath; 
        }


        public void Credentials(string inputEmail, string inputPass)
        {
            driver.FindElement(email).SendKeys(inputEmail);
            driver.FindElement(password).SendKeys(inputPass);
        }

        public IWebElement AssertTitle()
        {
            return driver.FindElement(lgnpagename);
        }

        public void ClickLoginBtn()
        {
            driver.FindElement(lgnbtn).Click();
        }

       public void LoggedIn()
        {
            driver.FindElement(lgnname).Click();    
        }

  
        public string AssertInvalidLogin()
        {
            string invalid = driver.FindElement(invalidText).Text;
            return invalid;
        }
    }
}
