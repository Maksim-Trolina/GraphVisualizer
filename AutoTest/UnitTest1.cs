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

        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";

        private const string WpfAppId = @"D:\Eugene27\GraphVisualizer\Forms\bin\Debug\netcoreapp3.1\Forms.exe";

        protected static WindowsDriver<WindowsElement> session;


        [Test]
        public void CreateNewGraph_ButtonClick_Test()
        {
            AppiumOptions opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", WpfAppId);

            session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), opt);

            session.FindElementByName("Load file").Click();

           // session.FindElementByName("Create").Click();

        }

        [Test]

        public void LoadFile_ButtonClick_Test()
        {


            //session.FindElementByName("Load graph").Click();



        }


    }
}