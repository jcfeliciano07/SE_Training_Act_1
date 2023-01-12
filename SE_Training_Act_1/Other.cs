using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace SE_Training_Act_1
{
    public class Other
    {


        [Test]
        public void Test_WindowHandles()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.open();");
            ReadOnlyCollection<string> handles = driver.WindowHandles;
            driver.SwitchTo().Window(handles[1]);
            driver.Url = "https://www.gmail.com";
            driver.SwitchTo().Window(handles[0]);

            //Console.WriteLine(driver.WindowHandles.Count);
            //Console.WriteLine(driver.CurrentWindowHandle);
            //Find element
            //IWebElement emailElement = driver.FindElement(By.Id("email"));
            //emailElement.SendKeys("Test@mailinator.com");

            //string title = driver.Url;
            //Count of element match with given locator
            //ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//ul/li"));
            //for (int i = 0; i < elements.Count; i++)
            //{
            //    Console.WriteLine(elements[i].Text);
            //    System.Console.WriteLine("Count: " + elements.Count);
            //}
        }

        [Test]
        public void DateTimePicker()
        {
            string dateToSelect = "11/29/2025";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demos.telerik.com/kendo-ui/datetimepicker/index");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement calendarPicker = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("span.k-link-date")));
            calendarPicker.Click();
            wait.Until(IWebDriver => driver.FindElement(By.Id("datetimepicker")).GetAttribute("aria-expanded").Equals("true"));
            IWebElement previous = driver.FindElement(By.XPath("//a[@data-action='prev']"));
            IWebElement next = driver.FindElement(By.XPath("//a[@data-action='next']"));
            IWebElement mid = driver.FindElement(By.XPath("//a[@data-action='nav-up']"));
            String currentDateTime = mid.Text;
            var current = currentDateTime.Split(" ", 2);
            var toSelect = dateToSelect.Split("/", 3);
            int yearDiff = Int32.Parse(current[1]) - Int32.Parse(toSelect[2]);
            mid.Click();
            if (yearDiff != 0)
            {

                if (yearDiff > 0)
                {
                    for (int i = 0; i < yearDiff; i++)
                    {
                        previous.Click();
                    }

                }
                if (yearDiff < 0)
                {
                    for (int i = 0; i < yearDiff * (-1); i++)
                    {
                        next.Click();
                    }
                }
            }
            Console.WriteLine("Month: " + Int32.Parse(toSelect[0]));
            ReadOnlyCollection<IWebElement> months = driver.FindElements(By.XPath("//div[@id='datetimepicker_dateview']//table//tbody//td[not(contains(@class,'k-other-month'))]"));
            months[Int32.Parse(toSelect[0]) - 1].Click();
            ReadOnlyCollection<IWebElement> dates = driver.FindElements(By.XPath("//div[@id='datetimepicker_dateview']//table//tbody//td[not(contains(@class,'k-other-month'))]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(dates[Int32.Parse(toSelect[1]) - 1]));
            dates[Int32.Parse(toSelect[1]) - 1].Click();

        }
    }
}