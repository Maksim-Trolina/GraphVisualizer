using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;



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

            Actions builder = new Actions(session);


            session.FindElementByName("Create new graph").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Create vertexes").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

             

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350 , 50 ).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 550, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 50).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 550, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 550, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 50).Click().Perform();


            session.FindElementByName("Закрыть").Click();

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


            session.FindElementByName("Закрыть").Click();

            session.Quit();


        }


        [Test]

        public void SaveGraph_Test()
        {

            AppiumOptions opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", fullPath);

            session = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), opt);

            Actions builder = new Actions(session);


            session.FindElementByName("Create new graph").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Create vertexes").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);



            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 50).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 50).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 300).Click().Perform();



            session.FindElementByName("Save that graph").Click();

            session.FindElementByClassName("Edit").SendKeys("AutomaticTestGraph");

            session.FindElementByName("Сохранить").Click();


            session.FindElementByName("Закрыть").Click();

            session.Quit();
        }

        [Test]

        public void CreateNewGraph_Matrix_Test()
        {

            AppiumOptions opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", fullPath);

            session = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), opt);

            Actions builder = new Actions(session);


            session.FindElementByName("Create new graph").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementsByClassName("WindowsForms10.EDIT.app.0.378734a_r3_ad1")[0].SendKeys("5");


            session.FindElementByName("OK").Click();


            session.FindElementsByClassName("WindowsForms10.EDIT.app.0.378734a_r3_ad1")[2].SendKeys("1");

            session.FindElementsByClassName("WindowsForms10.EDIT.app.0.378734a_r3_ad1")[8].SendKeys("4");

            session.FindElementsByClassName("WindowsForms10.EDIT.app.0.378734a_r3_ad1")[12].SendKeys("8");

            session.FindElementsByClassName("WindowsForms10.EDIT.app.0.378734a_r3_ad1")[23].SendKeys("8");


            session.FindElementByName("Create vertexes").Click();


            session.FindElementByName("Закрыть").Click();

            session.Quit();


        }

        [Test]

        public void PanelFunction_Test()
        {
            AppiumOptions opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", fullPath);

            session = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), opt);

            Actions builder = new Actions(session);


            session.FindElementByName("Create new graph").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Create vertexes").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);



            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 50).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 550, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 50).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 550, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 550, 300).Click();

            builder.MoveToElement(session.FindElementByName("Weight Table"), 350, 50).Click().Perform();


            session.FindElementByName("Weight Table").Click();                       

            session.FindElementByName("Weight Table").Click();



            session.FindElementByName("Adjacency List").Click();          

            session.FindElementsByClassName("WindowsForms10.EDIT.app.0.378734a_r3_ad1")[1].SendKeys("2");

            session.FindElementByName("Save Changes").Click();

            session.FindElementByName("Adjacency List").Click();



            session.FindElementByName("Show Cycle").Click();

            session.FindElementByName("Show Cycle").Click();



            session.FindElementByName("Shortest Path").Click();

            session.FindElementsByClassName("WindowsForms10.EDIT.app.0.378734a_r3_ad1")[1].SendKeys("2");

            session.FindElementByName("Find path").Click(); 

            session.FindElementByName("Shortest Path").Click();



            session.FindElementByName("Delete all").Click();



            session.FindElementByName("Закрыть").Click();

            session.Quit();

        }

        [Test]

        public void Transitions_Test()
        {

            AppiumOptions opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", fullPath);

            session = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), opt);

            Actions builder = new Actions(session);


            session.FindElementByName("Create new graph").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Create vertexes").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Menu").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Create new graph").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Create vertexes").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Matrix").Click();

            session.SwitchTo().Window(session.WindowHandles[0]);

            session.FindElementByName("Menu").Click();


            session.FindElementByName("Закрыть").Click();

            session.Quit();

        }

    }
}