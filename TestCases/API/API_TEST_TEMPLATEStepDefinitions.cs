using RestSharp;
using SupremeFramework.APIConfig;
using System;
using TechTalk.SpecFlow;
using SupremeFramework.Utils;

namespace SupremeFramework.Tests.API
{


   
    
    [Binding]

    
    public class API_TEST_TEMPLATEStepDefinitions
    {
        [Given(@"the user sets the baseUrl")]
        public void GivenTheUserSetsTheBaseUrl(Table table)
        {
            foreach (var row in table.Rows)
            {

            }
            
            
            SupremeAPI APIContainer = new SupremeAPI();
            APIContainer.baseUrl = "paramaterfromTable";
            


            Portal portal = new Portal();
            portal.API.Add("apiSetWithBaseUrl", APIContainer);

        }

        [When(@"\[action]")]
        public void WhenAction()
        {
            
        }

        [Then(@"\[outcome]")]
        public void ThenOutcome()
        {
            throw new PendingStepException();
        }
    }
}
