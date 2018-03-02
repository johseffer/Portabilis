using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Firefox;

namespace PortabilisTests.Firefox
{
    [TestClass]
    public class Application
    {
        public static FirefoxDriver StartApplication()
        {
            //var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;            
            var driver = new FirefoxDriver(@"C:\TFS\Portabilis\Tests\bin\Debug");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/");

            DoLogin(driver, "admin", "admin");

            Thread.Sleep(2000);

            return driver;
        }

        internal static void DoLogin(FirefoxDriver driver, string userName, string password)
        {
            driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/login");

            var emailInput = driver.FindElementById("exampleInputEmail1");
            emailInput.SendKeys(userName);

            var passwordInput = driver.FindElementById("exampleInputPassword1");
            passwordInput.SendKeys(password);

            var submitButton = driver.FindElementByClassName("btn-primary");
            submitButton.Submit();
        }

        internal static void DoLogout(FirefoxDriver driver)
        {
            driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/logout");
        }
    }
}
