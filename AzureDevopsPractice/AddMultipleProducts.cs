using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AzureDevopsPractice
{
    [TestClass]
    public class AddMultipleProducts
    {
        [TestMethod]
        public void addProducts()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.demoblaze.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(500);
            driver.FindElement(By.Id("login2")).Click();
            driver.FindElement(By.XPath("//input[@id='loginusername']")).SendKeys("megha123");
            driver.FindElement(By.Id("loginpassword")).SendKeys("Prince@123");
            driver.FindElement(By.XPath("//button[text()='Log in']")).Click();
            Thread.Sleep(2000);

            //******************************** Product1 **********************************//

            driver.FindElement(By.LinkText("Monitors")).Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,500);");

            driver.FindElement(By.XPath("//button[text()='Next']")).Click();
            driver.FindElement(By.LinkText("2017 Dell 15.6 Inch")).Click();
            IWebElement addToCart = driver.FindElement(By.LinkText("Add to cart"));
            addToCart.Click();

            Thread.Sleep(2000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            IWebElement homeButton = driver.FindElement(By.XPath("//a[text()='Home ']"));
            homeButton.Click();

            //******************************** Product2 **********************************//

            driver.FindElement(By.LinkText("Phones")).Click();

            js.ExecuteScript("window.scrollBy(0,600);");
            driver.FindElement(By.LinkText("Iphone 6 32gb")).Click();
            driver.FindElement(By.XPath("//h2[text()='Iphone 6 32gb']/..//a[text()='Add to cart']")).Click();

            Thread.Sleep(2000);
            IAlert alert1 = driver.SwitchTo().Alert();
            alert1.Accept();


            driver.FindElement(By.XPath("//a[text()='Home ']")).Click();

            //******************************** Product3 **********************************//


            driver.FindElement(By.XPath("//a[text()='Nexus 6']")).Click();
            driver.FindElement(By.XPath("//h2[text()='Nexus 6']/..//a[text()='Add to cart']")).Click();

            Thread.Sleep(2000);
            IAlert alert2 = driver.SwitchTo().Alert();
            alert2.Accept();

            driver.FindElement(By.XPath("//a[text()='Home ']")).Click();


            //******************************** Product4 **********************************//

            driver.FindElement(By.LinkText("Laptops")).Click();

            js.ExecuteScript("window.scrollBy(0,600);");

            driver.FindElement(By.LinkText("MacBook Pro")).Click();
            driver.FindElement(By.XPath("//h2[text()='MacBook Pro']/..//a[text()='Add to cart']")).Click();

            Thread.Sleep(2000);
            IAlert alert3 = driver.SwitchTo().Alert();
            alert3.Accept();

            driver.FindElement(By.LinkText("Cart")).Click();

            //IWebElement productsName = driver.FindElements(By.XPath("//tr[@class='success']"));
            IList<IWebElement> productsName = driver.FindElements(By.XPath("//a[text()='Delete']"));

            //Assert.That(productsName.Count > 0, "Seraching text is not found");
            //Console.WriteLine(productsName.Count());


            driver.FindElement(By.XPath("//td[text()='MacBook Pro']/..//a[text()='Delete']")).Click();
            driver.FindElement(By.XPath("//td[text()='2017 Dell 15.6 Inch']/..//a[text()='Delete']")).Click();

            IList<IWebElement> remainingProducts = driver.FindElements(By.XPath("//a[text()='Delete']"));

            //Assert.That(remainingProducts.Count > 0, "Seraching text is not found");
            //Console.WriteLine(remainingProducts.Count());

            IWebElement logout = driver.FindElement(By.LinkText("Log out"));
            Assert.IsTrue(logout.Displayed);

            logout.Click();
            driver.Quit();


        }
    }
}
