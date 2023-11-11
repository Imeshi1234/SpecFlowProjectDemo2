using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProjectDemo2.Utilities;

namespace SpecFlowProjectDemo2.pages
{
    public class LoginPage
    {
        public void LoginActions(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();

            //Lanuch turnup Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            //Thread.Sleep(1500);

            // Identify username textbox and enter valid username
            Wait.WaitToBeVisible(driver, "Id", "UserName", 5);
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            //Identify the password and enter valid passwaord
            IWebElement userpwdTextbox = driver.FindElement(By.Id("Password"));
            userpwdTextbox.SendKeys("123123");

            //Identify the Loging button and click the loging button
            IWebElement logingButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            logingButton.Click();
        }

        internal void LoginSteps(IWebDriver driver)
        {
            throw new NotImplementedException();
        }
    }






}
    

  
