using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;

namespace PortabilisTests.Chrome
{
    [TestClass]
    public class Application
    {
        public static ChromeDriver StartApplication()
        {
            //var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;            
            var driver = new ChromeDriver(@"C:\TFS\Portabilis\Tests\bin\Debug");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/");

            DoLogin(driver, "admin", "admin");

            Thread.Sleep(2000);

            return driver;
        }

        internal static void DoLogin(ChromeDriver driver, string userName, string password)
        {
            driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/login");

            var emailInput = driver.FindElementById("exampleInputEmail1");
            emailInput.SendKeys(userName);

            var passwordInput = driver.FindElementById("exampleInputPassword1");
            passwordInput.SendKeys(password);

            var submitButton = driver.FindElementByClassName("btn-primary");
            submitButton.Submit();
        }

        internal static void DoLogout(ChromeDriver driver)
        {
            driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/logout");
        }
    }
}
