using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProjectDemo2.Utilities;

namespace SpecFlowProjectDemo2.pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver, string code, string description, double price)
        {

            Wait.WaitToBeClickable(driver, "Xpath", "//*[@id=\"container\"]/p/a", 5);
            //Click on the Create new button for creating a new record in the time & materials module

            IWebElement createnewbutton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createnewbutton.Click();

            //Select the type code 

            IWebElement tnmoption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
            tnmoption.Click();
            Thread.Sleep(1000);

            IWebElement tmoption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            tmoption.Click();

            //Enter the code in the Code textbox
            IWebElement codetxtbox = driver.FindElement(By.Id("Code"));
            Wait.WaitToBeClickable(driver, "Id", "Code", 7);
            codetxtbox.SendKeys("New record");

            // Enter description in the description textbox
            IWebElement descriptiontxtbox = driver.FindElement(By.Id("Description"));
            Wait.WaitToBeVisible(driver, "Id", "Description", 7);
            descriptiontxtbox.SendKeys("data new record");


            //Enter the price per unit for the new record
            IWebElement pricetxtbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            pricetxtbox.SendKeys("321.45");

            //Click on the Save button 
            IWebElement savebutton = driver.FindElement(By.Id("SaveButton"));
            savebutton.Click();

            Thread.Sleep(6000);

        }

        public void AssertCreateTMRecord(IWebDriver driver, string code)
        {
            //Check whether the new record is created successfully 
            IWebElement lastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastpagebutton.Click();

            IWebElement newrecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            {

                // Ifthis part is not true print the message- (Assert.That(newrecord.Text == "New record")
                // print the No record found
                // we can use (assert.true) 
                Assert.That(newrecord.Text == code, "New time record not been created. Test Failed!");

            }

        }
        private WebDriverWait WebDriverWait(IWebDriver driver, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        //if (newCode.Text =="TurnUpPortalNunit")
        //    {
        //Assert.Pass("New time record has been created successfully");
        //    }
        //else
        //    {
        //Assert.Fail("Time record has been not created");
        //     }
        public void EditTimeRecord(IWebDriver driver, string code, string description, double price)
        {
            // Go to last Page 
            IWebElement lastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastpagebutton.Click();

            //Edit the new created record
            IWebElement editbutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editbutton.Click();

            //Edit the type code to material from time
            IWebElement editTypecode = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            editTypecode.Click();
            Thread.Sleep(1000);

            IWebElement edit1Typecode = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
            edit1Typecode.Click();

            //Edit the code textbox 
            IWebElement editcodetextbox = driver.FindElement(By.Id("Code"));
            editcodetextbox.Clear();
            editcodetextbox.SendKeys("Edited code");

            //Edit the description textbox
            IWebElement editdescriptiontextbox = driver.FindElement(By.Id("Description"));
            editdescriptiontextbox.Clear();
            editdescriptiontextbox.SendKeys("Edited description");
            Thread.Sleep(2000);

            //Edit price textbox
            IWebElement editpriceoverlappingtag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editpricetextbox = driver.FindElement(By.Id("Price"));
            editpriceoverlappingtag.Click();
            editpricetextbox.Clear();
            editpriceoverlappingtag.Click();

            editpricetextbox.SendKeys("980.76");

            //Download the edited record 
            IWebElement downloadbutton = driver.FindElement(By.Id("downloadButton"));
            downloadbutton.Click();

            //Save the edited record
            IWebElement editsavebutton = driver.FindElement(By.Id("SaveButton"));
            editsavebutton.Click();

            Thread.Sleep(4000);

        }
        public void AssertEditTMRecord(IWebDriver driver, string code)
        {
            //Check if the last record is edited successfully 
            IWebElement endpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            endpagebutton.Click();

            IWebElement editedrecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            {
                Assert.That(editedrecord.Text == code, "record has not been edited");
            }



            //if (editedrecord.Text == "Edited code")
            //{
            //    Assert.Pass("Record edited successfully");
            //}
            //else
            //{
            //    Assert.Fail("record has not been edited");
            //}

        }

        public void DeleteTimeRecord(IWebDriver driver)
        {
            // Go to last Page 
            IWebElement lastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastpagebutton.Click();

            //Delete the last created record
            IWebElement deletebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deletebutton.Click();
            driver.SwitchTo().Alert().Accept();
        }
        public void AssertDeleteTMRecord(IWebDriver driver)
        { 

            //Check if the record is deleted
            IWebElement endpgbutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            endpgbutton.Click();

            Thread.Sleep(2000);

            IWebElement deletedrecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            {
                Assert.That(deletedrecord.Text != "Edited code", "record has not been deleted ");
            }
        }
    }
}

        
    

  