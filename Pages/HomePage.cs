using OpenQA.Selenium;

using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMSelenium.Pages
{
    public class HomePage {  
       
       
        public IWebDriver driver;



        By login = By.XPath("//a[contains(text(), 'Login')]");
        By brandOther = By.XPath("//*[contains(text(), 'Other')]");
        By typeAll = By.XPath("//label[contains(@data-title, 'type')]/select/option[contains(text(), 'All')]");
        By hitArrowBtn = By.XPath("//input[contains(@class,'esh-catalog-send')]");
        By sixProducts = By.XPath("//div[contains(@class, 'container-fluid')]");
        By myOrders = By.XPath("//a/div[contains(text(),'My orders')]");
        By brandDropdown = By.XPath("//*[contains(@id, 'BrandFilter')]");
        By typeDropdown = By.XPath("//*[contains(@id, 'TypesFilter')]");

        //span[contains(text(), 'Prism White T-Shirt')]/../../input[contains(@class,  'esh-catalog-button')]
       

        public HomePage(IWebDriver driver) 
        
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this); 
        
        }


      



        //div[contains(text(), 'demouser')]
        public string xpath1 = "//span[contains(text(), '";
        public string xpath2 = "')]/../../input[contains(@class,  'esh-catalog-button')]";
        public string emailNameXPath = "//div[contains(text(), '";

        public string xpathForProductName(string productName)
        {
            string xpath = xpath1 + productName + xpath2;
            return xpath; 
        }

        public void addToBasketProductName(string productName)
       {
          string xpath =  xpathForProductName(productName);
      
           // IWebElement addToBasket = driver.FindElement(By.XPath(xpath));
           Utils utils = new Utils();
           IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.body.style.zoom = '80%'");

            
           Thread.Sleep(5000);
            //addToBasket.Click();


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                // Wait for an element to be clickable, for example, a button with id "myButton"
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                utils.ScrollTo(element, driver);

                IWebElement elementByXPath = (IWebElement)js.ExecuteScript($"return document.evaluate(\"{xpath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;");
               
                js.ExecuteScript("arguments[0].click();", elementByXPath);
                // Once the element is clickable, click it
               
            }
            catch (WebDriverTimeoutException ex)
            {
                // Handle the timeout exception if the element is not clickable within the specified timeout
                Console.WriteLine("Element is not clickable: " + ex.Message);
            }


            Console.WriteLine(xpath);
        }


        public void brandDropdownClick()
        {
            driver.FindElement(brandDropdown).Click();
        }

        public void typeDropdownClick()
        {
            driver.FindElement(typeDropdown).Click();
        }
        
        
        public void GoToLoginPage() {
            driver.FindElement(login).Click(); 
        }


        public void setBrand(string brandType)
        {
            switch(brandType)
            {
                case "All": setBrandAll(); break;
                case ".NET": setBrandNET(); break;
                case "Azure": setBrandAzure(); break;
                case "SQL Server": setBrandSQLServer(); break;
                case "Visual Studio": setBrandVisualStudio(); break;
                case "Other": setBrandOther(); break;
                default: Console.WriteLine("Brand type does not exist"); break;
               }
        }


        public void setType(string type)
        {
            switch (type)
            {
                case "All": setTypeAll(); break;
                case "Mug": setTypeMug(); break;
                case "Sheet": setTypeSheet(); break;
                case "T-Shirt": setTypeTShirt(); break;
                case "USB Memory Stick": setTypeUSB(); break;
            }
        }

        public void setTypeMug() { }
        public void setTypeSheet() { }
        public void setTypeTShirt() { }
        public void setTypeUSB() { }
        public void setBrandOther()
        {
            driver.FindElement(brandOther).Click();
        }

        public void setBrandAll() { }
        public void setBrandNET() { }
        public void setBrandAzure() { }
        public void setBrandSQLServer() { }
        public void setBrandVisualStudio() { }
        public void setTypeAll()
        {
            driver.FindElement(typeAll).Click();
        }


        public string emailNameXPathGen(string username)
        {
            string xpath = emailNameXPath + username + "')]";
            return xpath; 
        }


        public void HoverEmailName(string username)
        {
            string xpath = emailNameXPathGen(username);
            var emailElement = driver.FindElement(By.XPath(xpath));
            Actions action = new Actions(driver);
            action.MoveToElement(emailElement);
        
        }
        public void HitArrow()
        {
            driver.FindElement(hitArrowBtn).Click();
        }

        public string AssertSixProd()
        {
            string sixprod = driver.FindElement(sixProducts).Text;
            return sixprod;
        }

        public void ClickMyOrders()
        {
            driver.FindElement(myOrders).Click();
        }
    }

}

        



    

