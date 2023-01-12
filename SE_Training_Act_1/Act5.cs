using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SE_Training_Act_1


{
    public class Act5

    {

        IWebDriver driver = new ChromeDriver();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            driver.Manage().Window.Maximize();

        }
       // [OneTimeTearDown]
      //  public void OneTimeTearDown()
       // {
          // driver.Quit();

      //  }

        [Test]
        public void Test1_AssertAllFields()
        {
            Assert.IsTrue(driver.FindElement(By.Id("firstName")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("lastName")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("userEmail")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath(".//*[@id='genterWrapper']/div[2]/div[1]/label")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("userNumber")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("dateOfBirthInput")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='subjectsInput']")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath(".//*[@id='hobbiesWrapper']/div[2]/div[2]/label")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("uploadPicture")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("currentAddress")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//input[@id='react-select-3-input']")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='react-select-4-input']")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='submit']")).Displayed);

            Console.WriteLine("All Fields are displayed");

        }

        [Test]
        public void Test2_FillOutForm()
        {
            //IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            //driver.Manage().Window.Maximize();

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
           // IWebElement hobbie1Element = driver.FindElement(By.XPath("//label[contains(text(),'Sports')]"));
            //hobbie1Element.Click();
           // IWebElement hobbie2Element = driver.FindElement(By.XPath(".//*[@id='hobbiesWrapper']/div[2]/div[3]/label"));
           // hobbie2Element.Click();


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
            Thread.Sleep(3000);

            Console.WriteLine("All Fields were successfully populated");

        }

        [Test]
        public void Test3_AssertValues()
        {

            String actualValue = driver.FindElement(By.XPath("//tbody/tr[1]/td[2]")).Text;
            Assert.AreEqual("Jeremy Feliciano", actualValue);
            Console.WriteLine("Student name: " + actualValue);

            String actualValue1 = driver.FindElement(By.XPath("//tbody/tr[2]/td[2]")).Text;
            Assert.AreEqual("jcfeliciano07@gmail.com", actualValue1);
            Console.WriteLine("Student email: " + actualValue1);

            String actualValue2 = driver.FindElement(By.XPath("//tbody/tr[3]/td[2]")).Text;
            Assert.AreEqual("Male", actualValue2);
            Console.WriteLine("Gender: " + actualValue2);

            String actualValue3 = driver.FindElement(By.XPath("//tbody/tr[4]/td[2]")).Text;
            Assert.AreEqual("9473371342", actualValue3);
            Console.WriteLine("Mobile No.: " + actualValue3);

            String actualValue4 = driver.FindElement(By.XPath("//tbody/tr[5]/td[2]")).Text;
            Assert.AreEqual("16 May,2000", actualValue4);
            Console.WriteLine("Date of Birth : " + actualValue4);

            String actualValue5 = driver.FindElement(By.XPath("//tbody/tr[6]/td[2]")).Text;
            Assert.AreEqual("Maths, English", actualValue5);
            Console.WriteLine("Subjects: " + actualValue5);

            String actualValue6 = driver.FindElement(By.XPath("//tbody/tr[7]/td[2]")).Text;
            Assert.AreEqual("Reading, Music", actualValue6);
            Console.WriteLine("Hobbies: " + actualValue6);

            String actualValue7 = driver.FindElement(By.XPath("//tbody/tr[8]/td[2]")).Text;
            Assert.AreEqual("testUpload.jpg", actualValue7);
            Console.WriteLine("Picture: " + actualValue7);

            String actualValue8 = driver.FindElement(By.XPath("//tbody/tr[9]/td[2]")).Text;
            Assert.AreEqual("Teresa, Rizal", actualValue8);
            Console.WriteLine("Address: " + actualValue8);

            String actualValue9 = driver.FindElement(By.XPath("//tbody/tr[10]/td[2]")).Text;
            Assert.AreEqual("Uttar Pradesh Agra", actualValue9);
            Console.WriteLine("State & City: " + actualValue9);

        }
            [Test]
            public void Test4_ClosePopUp()
            {

            driver.Close();
            }
    }
}

