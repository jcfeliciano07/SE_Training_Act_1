using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Training_Act_1
{
    public class Act3
    {
        //Explicit Wait
        [Test]
        public void TestAct3_Implicit_Wait()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Console.WriteLine("Before: " + System.DateTime.Now.TimeOfDay);

            IWebElement element = null;
            try
            {
                element = driver.FindElement(By.Id("firstNamea")); //Id is incorrect
            }
            catch
            {
            }
            Console.WriteLine("After: " + System.DateTime.Now.TimeOfDay);

        }

        [Test]
        public void TestAct3_Explicit_Wait()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement fNameElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("firstName")));
            fNameElement.SendKeys("Jeremy");
            IWebElement lNameElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lastName")));
            lNameElement.SendKeys("Feliciano");
            IWebElement eMailElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("userEmail")));
            eMailElement.SendKeys("jcfeliciano07@gmail.com");
            IWebElement genderElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='genterWrapper']/div[2]/div[1]")));
            genderElement.Click();

        }

            [Test]
            public void TestAct3_Fluent_Wait()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(5);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.Message = "Element to be searched not found";
                IWebElement genderElement = fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='genterWrapper']/div[2]/div[1]"))); //add extra 1 at the end is used to simulate the sce element not found
                genderElement.Click();
        }
        }
    }
