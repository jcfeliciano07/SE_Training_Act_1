using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace SE_Training_Act_1
{
    public class Act1
    {
   

        [Test]
        public void AccessURL_Act1()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            //driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://www.facebook.com");
            string title = driver.Title;
            System.Console.WriteLine("Current Browser Title: " + title);
            System.Console.WriteLine("Length of Current Browser Title: " + title.Length);
            driver.Navigate().Back();
            string title1 = driver.Title;
            System.Console.WriteLine("Back Browser Title: " + title1);
            System.Console.WriteLine("Length of Back Browser Title: " + title1.Length);
            driver.Navigate().Forward();
            string title2 = driver.Title;
            Console.WriteLine("Forward Browser Title: " + title2 + " & Length is " + title2.Length);
            Thread.Sleep(5000);
            driver.Navigate().Refresh();
            driver.Quit();
            
        }
    }
}