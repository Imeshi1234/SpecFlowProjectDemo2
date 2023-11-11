using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectDemo2.pages
{
    public class HomePage
    {
        public void VerifySucessLogin(IWebDriver driver)
        {
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

            if (helloHari.Text == "Hello hari")
            {
                Console.WriteLine("User has logged in successfully");
            }
            else
            {
                Console.WriteLine("Üser has not logged in");
            }
        }
        public void GoToTMPage(IWebDriver driver)
        {
            try
            {

                IWebElement AdmintrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
                AdmintrationDropdown.Click();
            }
            catch (Exception exception)
            {
                // using exceptions we are telling where is the root cause to the problem
                Assert.Fail("Turnup portal not displayed", exception.Message);

            }

            IWebElement clickTMOption = driver.FindElement(By.XPath("//a[contains(text(),'Time & Materials')]"));
            clickTMOption.Click();

        }

        public void GoToEmployeePage()
        {
            //code to navigates to employee page
        }


    }










}
   