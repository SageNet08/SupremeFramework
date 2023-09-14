using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMSelenium.Pages
{
    public class Basket 
    {

        IWebDriver driver;
        public Basket(IWebDriver driver) { 
            this.driver = driver; 
            PageFactory.InitElements(driver, this);
        }

        By basketBtn = By.ClassName("esh-catalog-button");
        //By checkOutBtn = By.XPath("//a[contains(text(), 'Checkout')]");
        By checkOutBtn = By.XPath("/html/body/div/div/form/div/div[3]/section[2]/a");

        //By quantity = By.XPath("//input[contains(@name, 'Quantity')]");





        By payNowBtn = By.XPath("//input[contains(@value, 'Pay')]");
        By continueShop = By.XPath("//a[contains(text(), '[ Continue Shopping ]')]");
        By updatebtn = By.XPath("//button");




        public string quantityXPathBuilder(string itemName)
        {

            //section[contains(text(), 'White')]/../section/input[contains(@class, 'esh-basket-input')]
            string x1 = "//section[contains(text(), '";
            string x2 = "')]/../section/input[contains(@class, 'esh-basket-input')]";
            string xpath =  x1 + itemName + x2;
            return xpath;

        }


        public void  addToBasket()
        {


            driver.FindElement(basketBtn).Click();
        }

        //public string AssertCheckOut()
        //{
        //    string checkout = driver.FindElement(checkOutBtn).Text;
        //    return checkout;

        // }

        public void setQuantity(string quant, string itemname)
        {
            string xpath = quantityXPathBuilder(itemname);
            driver.FindElement(By.XPath(xpath));
            driver.FindElement(By.XPath(xpath)).Clear();
            driver.FindElement(By.XPath(xpath)).SendKeys(quant);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(xpath)).SendKeys(Keys.Return);
        }

       public void CheckOut()
       {
           IWebElement checkOut = driver.FindElement(checkOutBtn);
           Utils util = new Utils();

           util.ScrollTo(checkOut, driver);
           checkOut.Click();

            

        }

        public void PayNow()
        {

           IWebElement payNow = driver.FindElement(payNowBtn);


            Utils utils = new Utils();
            utils.ScrollTo(payNow, driver);

            

            payNow.Click();



        }


        public void Update()
        {
            IWebElement updateBtn = driver.FindElement(updatebtn); 
         //   ScrollTo(updateBtn, driver);
            updateBtn.Click();
        }
       

        public void loopProducts()
        {
            IReadOnlyCollection<IWebElement> loopEl;
            loopEl = driver.FindElements(basketBtn);
           
           
            foreach(IWebElement productsAdd in loopEl) {
                productsAdd.Click();
                driver.FindElement(continueShop).Click();
                Thread.Sleep(5000);

            }
        }

        public string AssertBasketPage()
        {
            string title = driver.Title;
            return title;
        }

        public void ContinueShopping()
        {
            IWebElement continueB = driver.FindElement(continueShop);
            Utils utils = new Utils();
            utils.ScrollTo(continueB, driver);
            continueB.Click();

            Thread.Sleep(10);

        }

    }
}
