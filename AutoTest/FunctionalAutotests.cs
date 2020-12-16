using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using OpenQA.Selenium.Appium;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;


namespace AutoTest
{
    public class Tests
    {

        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/";

        private const string WpfAppId = @"..\..\..\..\Forms\bin\Debug\netcoreapp3.1\Forms.exe";

        private string fullPath = Path.GetFullPath(WpfAppId);

        protected static RemoteWebDriver session;


        [Test]
        public void CreateNewGraph_Draw_Test()
        {
            AppiumOptions opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", fullPath);

            session = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), opt);
          

            session.FindElementByName("Create new graph").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Create vertexes").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            Actions builder = new Actions(session); 


            builder.MoveToElement(session.FindElementByName("Weight Table"), 350 , 50 ).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 550, 300).Click();


            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 50).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 550, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 550, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 50).Click().Perform();

            session.Quit();
        }

        [Test]

        public void SaveGraph_Test()
        {

            CreateNewGraph_Draw_Test();

            Actions builder = new Actions(session);

            session.FindElementByName("Save that graph").Click();

            session.FindElementByName("Имя файла:").SendKeys("AutomaticTestGraph");

            builder.DoubleClick(session.FindElementByName("Сохранить")).Perform();


            session.Quit();
        }

        [Test]

        public void GraphLoading_Test()
        {

            AppiumOptions opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", fullPath);

            session = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), opt);

            Actions builder = new Actions(session);


            session.FindElementByName("Load file").Click();

            builder.DoubleClick(session.FindElementByName("AutomaticTestGraph.json")).Perform();

            session.Quit();


        }


    }
}