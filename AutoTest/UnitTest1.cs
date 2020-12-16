using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using OpenQA.Selenium.Appium;
using System.Diagnostics;


namespace AutoTest
{
    public class Tests
    {

        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/";

        private const string WpfAppId = @"C:\Users\DONBASS\Desktop\GraphVisualizer\Forms\bin\Debug\netcoreapp3.1\Forms.exe";

        protected static RemoteWebDriver session;


        [Test]
        public void CreateNewGraph_ButtonClick_Test()
        {
            AppiumOptions opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", WpfAppId);

            session = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), opt);

            session.FindElementByName("Create new graph").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Create vertexes").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Menu").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Load file").Click();
        }

        [Test]

        public void LoadFile_ButtonClick_Test()
        {


            //session.FindElementByName("Load graph").Click();



        }


    }
}