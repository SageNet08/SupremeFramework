using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMSelenium.Pages
{
    public class PageRunner : Browser
    {
        
        public Browser? browser { get; set  ; }
      
        public HomePage? homePage { get; set; }
        public LoginPage? loginPage { get; set; }
        public Orders? orderPage { get; set; }

        public Basket? basketPage { get; set; }


      // public PageRunner(IWebDriver driver)
      //  {
       //     _driver = driver;
       //     browser = new Browser();
        //    homePage = new HomePage(_driver); 
         //   loginPage = new LoginPage(_driver);
         //   orderPage = new Orders(_driver);
         //   basketPage = new Basket(_driver);
       // }
    }
}
