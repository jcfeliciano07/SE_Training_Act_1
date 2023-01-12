using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SE_Training_Act_1
{
    public class Act2
    {
   

        [Test]
        public void FillOutRegForm_Act2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            driver.Manage().Window.Maximize();
            //Input Firstname
            IWebElement fNameElement = driver.FindElement(By.Id("firstName"));
            fNameElement.SendKeys("Jeremy");
            //Console.WriteLine("Firstname: " + fNameElement.GetAttribute("value"));
            //Input Lastname
            IWebElement lNameElement = driver.FindElement(By.Id("lastName"));
            lNameElement.SendKeys("Feliciano");
            //Input email address
            IWebElement eMailElement = driver.FindElement(By.Id("userEmail"));
            eMailElement.SendKeys("jcfeliciano07@gmail.com");
            //Choose gender
            IWebElement genderElement = driver.FindElement(By.XPath(".//*[@id='genterWrapper']/div[2]/div[1]/label"));
            genderElement.Click();
            //Input mobile number
            IWebElement mobileElement = driver.FindElement(By.Id("userNumber"));
            mobileElement.SendKeys("9473371342");
            //select birth date
            IWebElement userBirthElement = driver.FindElement(By.Id("dateOfBirthInput"));
            userBirthElement.Click();
            //Select Month
            IWebElement monthElement = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            SelectElement element = new SelectElement(monthElement);
            element.SelectByText("May");
            //Select Year
            IWebElement yearElement = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            SelectElement element1 = new SelectElement(yearElement);
            element1.SelectByText("2000");
            //Select day
            IWebElement dayElement = driver.FindElement(By.ClassName("react-datepicker__day--016"));
            dayElement.Click();

            //Add Subjects
            IWebElement subjectElement = driver.FindElement(By.XPath("//*[@id='subjectsInput']"));
            //Thread.Sleep(2000);
            subjectElement.SendKeys("Maths");
            subjectElement.SendKeys(Keys.Enter);
            subjectElement.SendKeys("English");
            subjectElement.SendKeys(Keys.Enter);
            //Choose Hobbies
            IWebElement hobbie1Element = driver.FindElement(By.XPath("//label[@for='hobbies-checkbox-1']"));
            hobbie1Element.Click();
            IWebElement hobbie2Element = driver.FindElement(By.XPath("//label[@for='hobbies-checkbox-2']"));
            hobbie2Element.Click();
          

            //Upload picture
            IWebElement uploadelement = driver.FindElement(By.Id("uploadPicture"));
            uploadelement.SendKeys("C:\\Users\\jeremy.feliciano\\Documents\\testUpload.jpg");

            //Input Address
            IWebElement currentAddElement = driver.FindElement(By.Id("currentAddress"));
            currentAddElement.SendKeys("Teresa, Rizal");
            //Select State
            IWebElement stateDropdownList = driver.FindElement(By.XPath("//input[@id='react-select-3-input']"));
            stateDropdownList.SendKeys("Uttar Pradesh");
            stateDropdownList.SendKeys(Keys.ArrowDown);
            stateDropdownList.SendKeys(Keys.Enter);
            //Select City
            IWebElement cityDropdownList = driver.FindElement(By.XPath("//*[@id='react-select-4-input']"));
            cityDropdownList.SendKeys("Agra");
            cityDropdownList.SendKeys(Keys.ArrowDown);
            cityDropdownList.SendKeys(Keys.Enter);
            //Click Submit
            IWebElement submitElement = driver.FindElement(By.XPath("//*[@id='submit']"));
            submitElement.Click();

            //Wait to validate the data
            Thread.Sleep(5000);

            //Print contents
            var content1 = driver.FindElement(By.XPath("//tbody/tr[1]/td[2]")).Text;
            Console.WriteLine("Student name: " + content1);
            var content2 = driver.FindElement(By.XPath("//tbody/tr[2]/td[2]")).Text;
            Console.WriteLine("Student email: " + content2);
            var content3 = driver.FindElement(By.XPath("//tbody/tr[3]/td[2]")).Text;
            Console.WriteLine("Gender: " + content3);
            var content4 = driver.FindElement(By.XPath("//tbody/tr[4]/td[2]")).Text;
            Console.WriteLine("Mobile: " + content4);
            var content5 = driver.FindElement(By.XPath("//tbody/tr[5]/td[2]")).Text;
            Console.WriteLine("Date of Birth: " + content5);
            var content6 = driver.FindElement(By.XPath("//tbody/tr[6]/td[2]")).Text;
            Console.WriteLine("Subjects: " + content6);
            var content7 = driver.FindElement(By.XPath("//tbody/tr[7]/td[2]")).Text;
            Console.WriteLine("Hobbies: " + content7);
            var content8 = driver.FindElement(By.XPath("//tbody/tr[8]/td[2]")).Text;
            Console.WriteLine("Picture: " + content8);
            var content9 = driver.FindElement(By.XPath("//tbody/tr[9]/td[2]")).Text;
            Console.WriteLine("Address: " + content9);
            var content10 = driver.FindElement(By.XPath("//tbody/tr[10]/td[2]")).Text;
            Console.WriteLine("State and City: " + content10);

            driver.Quit();
        }
    }
}