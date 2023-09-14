using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMSelenium
{
    public class Utils
    {
        public Utils()
        {
            
        }




        

        public void ScrollTo(IWebElement element, IWebDriver driver)
        {

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            Thread.Sleep(2000);
        }



    }
}
