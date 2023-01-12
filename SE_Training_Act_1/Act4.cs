using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SE_Training_Act_1
{
    public class Act4
    {
        [Test]
        public void IFrame_Act4()
        {
            //Navigate to URL
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/demo-site/frames-and-windows/.");
            driver.Manage().Window.Maximize();

            //Click on IFrame tab
            driver.FindElement(By.Id("iFrame")).Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,300)");

            Thread.Sleep(5000);

            //witch to frame with name "globalSqa"
            driver.SwitchTo().Frame("globalSqa");

            //Hover "SAP Hybris Training" and print the title.
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath(".//*[@id='portfolio_items']/div[2]"))).Build().Perform();

            var content0 = driver.FindElement(By.XPath(".//*[@id='portfolio_items']/div[2]/a/div/div/div[1]/img")).GetAttribute("alt");
            Console.WriteLine("Training Title: " + content0);


            Thread.Sleep(5000);

            //Click the title
            action.Click(driver.FindElement(By.XPath(".//*[@id='portfolio_items']/div[2]"))).Build().Perform();

            Thread.Sleep(5000);
            //Print the details of the training
            var content1 = driver.FindElement(By.XPath(".//*[@id='wrapper']/div/div[2]/div/div/div")).Text;
            Console.WriteLine("Training Details: " + content1);


            //Click on the toogle menu button and click Home.
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement togglebutton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("mobile_menu_toggler")));
            togglebutton.Click();

            IWebElement homebtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='mobile_menu']/ul/li[1]/a")));
            homebtn.Click();


            //Print the contact info below
            var contact = driver.FindElement(By.XPath(".//*[@id='footer']/div[1]/div[1]/div[3]")).Text;
            Console.WriteLine("Contact Details: " + contact);

            driver.Quit();

        }


    }
}
