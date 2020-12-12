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

    
        [Test]
        public void CreateNewGraph_Click_Test()
        {
            AppiumOptions opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", @"D:\Eugene27\GraphVisualizer\Forms\bin\Debug\netcoreapp3.1\Forms.exe");

            var session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), opt);

            session.FindElementByName("Create new graph").Click();
            
        }


    }
}