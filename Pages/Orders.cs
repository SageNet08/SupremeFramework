using Microsoft.VisualStudio.CodeCoverage;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POMSelenium.Pages
{
    public class Orders
    {

        IWebDriver driver { get; }
        public Orders(IWebDriver driver) { this.driver = driver; PageFactory.InitElements(driver, this); }

        //code might fail when you clear order history, dont forget that 

        By detail = By.XPath("//a[contains(@href, '/order/detail/20')]");
        By priceText = By.XPath("//article/section[contains(text(), '$ 9,468.00')][1]");

        By emptybasket = By.TagName("h3");
        By quantityForm = By.XPath("//input[contains(@class, 'esh-basket-input')]");
        


        public string detailXPath = "//a[contains(@href, '";

        public void clickLastDetails() 
        {
            
            string hrefPrefix = "//a[contains(@href, '/order/detail/')]";
           IReadOnlyList<IWebElement> detailElements = driver.FindElements(By.XPath(hrefPrefix));
           IList<int> lastDetail = new List<int>(); 
            foreach(var i in detailElements)
            {
                string htmlContent = i.GetAttribute("outerHTML");
                MatchCollection matches = Regex.Matches(htmlContent, @"\d+");
                string result = string.Join("", matches);
                lastDetail.Add(int.Parse(result));

               
            }
            int max = int.MinValue;
            foreach(int number in lastDetail)
            {
                if(number > max)
                {
                    max = number;
                }


            }

            string XPath = "//a[contains(@href, '/order/detail/" + max + "')]";

            var detailElement = driver.FindElement(By.XPath(XPath));
            
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", detailElement);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            Thread.Sleep(2000);
            detailElement.Click();

        }
        
        public string Detect()
        {
            IWebElement element = driver.FindElement(quantityForm);

            // Use JavaScript Executor to get the validationMessage property
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            string validationMessage = (string)jsExecutor.ExecuteScript("return arguments[0].validationMessage;", element);

            // Print the validationMessage
            Console.WriteLine("Validation Message: " + validationMessage);

            return validationMessage;
        }


        public void GoToDetail()
        {
            driver.Navigate().GoToUrl("http://localhost:17469/order/detail/7");
        }

      

        public string AssertQuantity(string quantity)
        {
            string xpath = buildItemXPath(quantity);
            string quantityText = driver.FindElement(By.XPath(xpath)).Text;

            return quantityText;


        }



        public string AssertProdName(string productname)
        {
            string xpath = buildItemXPath(productname);
            string productNameText = driver.FindElement(By.XPath(xpath)).Text;

            return productNameText;
        }
        public string buildItemXPath(string itemXPath)
        {
            string x1 = "//section[text() ='";
            string x2 = "']";
            string fullPath = x1 + itemXPath + x2;
            return fullPath;
        }

        public string AssertBasketEmpty()
        {
            string emptyBasket = driver.FindElement(emptybasket).Text;
            return emptyBasket;
        }
    }
}
