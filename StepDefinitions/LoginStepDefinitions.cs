using System;
using TechTalk.SpecFlow;
using POMSelenium;
using POMSelenium.Pages;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.DevTools;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Firefox;
using System.Linq;
using OpenQA.Selenium.Chrome;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using BoDi;
using POMSelenium.Hooks;

namespace POMSelenium.StepDefinitions
{
    [Binding]

    public class LoginStepDefinitions : Browser

    {

        LoginPage loginPage;
                 
        private List<Dictionary<string, string>> tableData = new List<Dictionary<string, string>>();
      
       


        [Given(@"the user is on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            
            driver.Navigate().GoToUrl("https://localhost:44315/");
            Thread.Sleep(5000);
            
     
            }




        [When(@"the user click the Login link")]
        public void WhenIClickTheLoginButton()
        {
            Thread.Sleep(1000);


            loginPage = new LoginPage(driver);
         
            loginPage.ClickLoginBtn();
            

        }


        [Then(@"the user is on the Login Page")]

        public void ThenLoginPageAppears()
        {
            Thread.Sleep(1000);





            var lgnname = loginPage.AssertTitle();
            Assert.IsTrue(lgnname.Text.Contains("Log in"), "Not found");



        }


        [Given(@"the user is on the Login Page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            var lgnname = loginPage.AssertTitle();
            Assert.IsTrue(lgnname.Text.Contains("Log in"), "Not found");



        }

        [When(@"the user enters the credentials and click the login button")]
        public void WhenIEnterCredentials(Table table)
        {
            //  tableData = new List<Dictionary<string, string>>();
            loginPage = new LoginPage(driver); 

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

                loginPage.Credentials(rowData["username"], rowData["password"]);
                loginPage.LoggedIn();
                break;
            }

            
        }



        

      
        [Then(@"the user is logged in as emailname")]
        public void ThenLoginSuccessfullWithUsername(Table table)
        {



            foreach (var rowData in tableData)
            {
                
                
                var username = rowData["username"];
                
                string xpathforUsername = loginPage.XpathBuilder(username);
                var el = loginPage.GetElement(xpathforUsername); 
                
              
                
                Assert.IsTrue(el.Text.Contains(username), "Not found");
                
                break;
            }
            
            
        }



       
       


        [Then(@"Invalid Login")]
        public void ThenInvalidLogin()
        {
            string invalidlgn = loginPage.AssertInvalidLogin();
            Assert.IsTrue(invalidlgn.Contains("Invalid login attempt."));
            

        }



    }
}
