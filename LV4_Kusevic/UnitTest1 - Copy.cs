using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Registration

    {
        private static readonly Random _random = new Random();

        // Generates a random number within a range.      
        public static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }


        private IWebDriver driver;
    private StringBuilder verificationErrors;
    private string baseURL;
    private bool acceptNextAlert = true;
    private int randomNum = RandomNumber(1, 100000);

    [SetUp]
    public void SetupTest()
    {
        driver = new FirefoxDriver();
        baseURL = "https://www.google.com/";
        verificationErrors = new StringBuilder();
    }

    [TearDown]
    public void TeardownTest()
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        {
            // Ignore errors if unable to close the browser
        }
        Assert.AreEqual("", verificationErrors.ToString());
    }

        [Test]
    public void The6Test()
    {

        driver.Navigate().GoToUrl("https://demo.opencart.com/");
        driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/i")).Click();
        driver.FindElement(By.LinkText("Register")).Click();
        driver.FindElement(By.Id("input-firstname")).Click();
        driver.FindElement(By.Id("input-firstname")).Clear();
        driver.FindElement(By.Id("input-firstname")).SendKeys("Tomislav");
        driver.FindElement(By.Id("input-lastname")).Clear();
        driver.FindElement(By.Id("input-lastname")).SendKeys("Kusevic");
        driver.FindElement(By.Id("input-email")).Clear();
        driver.FindElement(By.Id("input-email")).SendKeys("fixing" + randomNum +  "@gmail.com");
        driver.FindElement(By.Id("input-telephone")).Clear();
        driver.FindElement(By.Id("input-telephone")).SendKeys("1234");
        driver.FindElement(By.Id("input-password")).Clear();
        driver.FindElement(By.Id("input-password")).SendKeys("pass1234");
        driver.FindElement(By.Id("input-confirm")).Clear();
        driver.FindElement(By.Id("input-confirm")).SendKeys("pass1234");
        driver.FindElement(By.XPath("//div[@id='content']/form/fieldset[3]/div/div/label[2]")).Click();
        driver.FindElement(By.Name("agree")).Click();
        driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
        driver.FindElement(By.LinkText("Continue")).Click();
    }
    private bool IsElementPresent(By by)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    private bool IsAlertPresent()
    {
        try
        {
            driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

    private string CloseAlertAndGetItsText()
    {
        try
        {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (acceptNextAlert)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
            return alertText;
        }
        finally
        {
            acceptNextAlert = true;
        }
    }
}
}
