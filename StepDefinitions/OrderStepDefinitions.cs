using System;
using TechTalk.SpecFlow;
using POMSelenium;
using POMSelenium.Pages;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.DevTools;
using LivingDoc.Dtos;
using System.Linq.Expressions;
using System.Data;
using Microsoft.VisualStudio.CodeCoverage;
using OpenQA.Selenium.Chrome;

namespace POMSelenium.StepDefinitions
{
    [Binding]

    
    public class OrderStepDefinitions : Browser

    {
        
        Orders orderPage;
        Basket basketPage;
        Browser browser;
        HomePage homePage;


        private List<Dictionary<string, string>> tableData = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> tableData2 = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> tableData3 = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> tableData4 = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> tableData5 = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> tableData6 = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> tableData7 = new List<Dictionary<string, string>>();

        

        [Given(@"the user is logged in with credentials")]
        public void GivenIHaveLoggedOnEShop(Table table)

        {
        
            



        }



        [When(@"the user selects the brand and the type filters of the products")]
        public void WhenIChooseOtherAndAll(Table table)
        {
            //need to Pass Driver through Hooks ?? 

            homePage = new HomePage(driver); 
            homePage.brandDropdownClick();
          

           

         
            Thread.Sleep(10000);


            foreach (TableRow row in table.Rows)
            {

                var rowData = new Dictionary<string, string>();
                foreach (var header in table.Header)
                {
                    rowData[header] = row[header];
                }

                tableData.Add(rowData);
            }

            foreach (var rowData in tableData)
            {
                homePage.setBrand(rowData["brand"]);
                homePage.typeDropdownClick();
                homePage.setType(rowData["type"]);
            }

            homePage.HitArrow();




        }




        [When(@"the user adds an item to basket")]
        public void WhenTheUserAddsAnItemToBasket(Table table)
        {
            foreach (TableRow row in table.Rows)
            {

                var rowData = new Dictionary<string, string>();
                foreach (var header in table.Header)
                {
                    rowData[header] = row[header];
                }

                tableData2.Add(rowData);
            }

            foreach (var rowData in tableData2)
            {
               homePage.addToBasketProductName(rowData["items"]);
            }
        }


        [When(@"the Basket page appears")]
        public void WhenTheBasketPageAppears()
        {
            basketPage = new Basket(driver); 
            string title = basketPage.AssertBasketPage();
            Assert.IsTrue(title.Contains("Basket"));
        }


        [When(@"the user checks out with the required quantity")]
        public void WhenTheUserInputsTheQuantityOfThatItem(Table table)
        {
            
            foreach (TableRow row in table.Rows)
            {

                var rowData = new Dictionary<string, string>();
                foreach (var header in table.Header)
                {
                    rowData[header] = row[header];
                }

                tableData3.Add(rowData);
            }

            foreach (var rowData in tableData3)
            {
            
                basketPage.setQuantity(rowData["quantity"], "Prism White T-Shirt");
            }


            basketPage.CheckOut();
            
        }



        [When(@"the user completes payment")]
        public void WhenTheUserCompletesPayment()
        {
            basketPage = new Basket(driver);
            basketPage.PayNow();
            Thread.Sleep(1000);
            browser = new Browser();
            string title = browser.Title(driver);
            Assert.That(title.Contains("Checkout Complete"));
        }



        [When(@"the user access his orders")]
        public void WhenTheUserAccessHisOrders(Table table)
        {
            foreach (TableRow row in table.Rows)
            {

                var rowData = new Dictionary<string, string>();
                foreach (var header in table.Header)
                {
                    rowData[header] = row[header];
                }

                tableData4.Add(rowData);
            }

            foreach (var rowData in tableData4)
            {
                homePage.HoverEmailName(rowData["username"]);
                homePage.ClickMyOrders();

            }

        }

        [Then(@"the MyOrder History is verified")]
        public void ThenTheMyOrderHistoryIsVerified(Table table)
        {
            orderPage = new Orders(driver); 
            orderPage.clickLastDetails();


            foreach (TableRow row in table.Rows)
            {

                var rowData = new Dictionary<string, string>();
                foreach (var header in table.Header)
                {
                    rowData[header] = row[header];
                }

                tableData5.Add(rowData);
            }

            foreach (var rowData in tableData5)
            {
                orderPage.AssertProdName(rowData["items"]);
                orderPage.AssertQuantity(rowData["quantity"]);
              
                
            }


        }

        [When(@"the user tries to check out with an invalid quantity")]
        public void WhenTheUserChecksOutWithInvalidQuantity(Table table)
        {
            orderPage = new Orders(driver);
            foreach (TableRow row in table.Rows)
            {

                var rowData = new Dictionary<string, string>();
                foreach (var header in table.Header)
                {
                    rowData[header] = row[header];
                }

                tableData6.Add(rowData);
            }

            foreach (var rowData in tableData6)
            {
                basketPage.setQuantity(rowData["quantity"], "Prism White T-Shirt");


            }

            orderPage.Detect();
            

        }





        [Then(@"user gets an error message")]
        public void ThenUserGetsAnErrorMessage()
        {
            string validationMsg = orderPage.Detect();
            Assert.IsNotNull(validationMsg);

        }



        [When(@"the user adds 5 items to basket")]
        public void WhenTheUserAddsItemsToBasket(Table table)
        {

            basketPage = new Basket(driver);

            foreach (TableRow row in table.Rows)
            {

                var rowData = new Dictionary<string, string>();
                foreach (var header in table.Header)
                {
                    rowData[header] = row[header];
                }

                tableData7.Add(rowData);
            }

            int count = 0;
            foreach (var counting in tableData7)
            {
                count++;
            }


            int count2 = 0; 
            foreach (var rowData in tableData7)
            {
                count2++; 
                homePage.addToBasketProductName(rowData["items"]);
                basketPage.setQuantity(rowData["quantity"], rowData["items"]);

                if (count2 == count) { break; }
                else


                {
                    basketPage.ContinueShopping();
                    homePage.brandDropdownClick();
                    homePage.setBrand(rowData["brand"]);
                    homePage.typeDropdownClick();
                    homePage.setType(rowData["type"]);
                    homePage.HitArrow();
                    Thread.Sleep(1000);
                }

            }
        }




        [When(@"the user checks out the five items")]
        public void WhenTheUserChecksOutTheFiveItems()
        {
            basketPage.CheckOut();
        }















    }
}
