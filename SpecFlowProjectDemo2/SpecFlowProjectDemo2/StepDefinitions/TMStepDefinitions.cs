using OpenQA.Selenium.Chrome;
using SpecFlowProjectDemo2.pages;
using SpecFlowProjectDemo2.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectDemo2.StepDefinitions
{
    [Binding]
    public class TMStepDefinitions:CommonDriver
    { 
       LoginPage loginObj = new LoginPage();
    HomePage homepageObj = new HomePage();
    TMPage tmpageObj = new TMPage();
    
        [Given(@"user logs into TurnUp Portal")]
        public void GivenUserLogsIntoTurnUpPortal()
        {
          //LoginPage loginObj = new LoginPage();
          //HomePage homepageObj = new HomePage();
         // TMPage tmpageObj = new TMPage();

            driver = new ChromeDriver();
            Thread.Sleep(1000);
                

            //LoginPage page object initialization and definition
            
            loginObj.LoginActions(driver);

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            
            
        }

        [Given(@"user navigates to time and material page")]
        public void GivenUserNavigatesToTimeAndMaterialPage()
        {
            
            homepageObj.VerifySucessLogin(driver);
            homepageObj.GoToTMPage(driver);
        }

        [When(@"user creates a new time and material record")]
        public void WhenUserCreatesANewTimeAndMaterialRecord()
        {
            tmpageObj.CreateTimeRecord(driver, "New record", "data new record", 321.45);
        }

        [Then(@"turnup portal should save the new time and material record")]
        public void ThenTurnupPortalShouldSaveTheNewTimeAndMaterialRecord()
        {
            tmpageObj.AssertCreateTMRecord(driver, "New Record");

        }
        [When(@"user edits an existing time and material record")]
        public void WhenUserEditsAnExistingTimeAndMaterialRecord()
        {
            tmpageObj.EditTimeRecord(driver, "Edited code", "Edited description", 980.76);
        }

        [Then(@"turnup portal should save the existing time and material record")]
        public void ThenTurnupPortalShouldSaveTheExistingTimeAndMaterialRecord()
        {
            tmpageObj.AssertEditTMRecord(driver, "Edited code");

        }
        [When(@"user delete an existing time and material record")]
        public void WhenUserDeleteAnExistingTimeAndMaterialRecord()
        {
            tmpageObj.DeleteTimeRecord(driver);
        }

        [Then(@"turnup portal should delete the existing time and material record")]
        public void ThenTurnupPortalShouldDeleteTheExistingTimeAndMaterialRecord()
        {
            tmpageObj.AssertDeleteTMRecord(driver);
        }


    }
}
