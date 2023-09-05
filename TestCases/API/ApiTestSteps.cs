using RestSharp;
using SupremeFramework.APIConfig;
using System;
using TechTalk.SpecFlow;
using SupremeFramework.Utils; 
using System.Diagnostics;
using RestSharp.Serializers.Xml;
using Newtonsoft.Json;
using SupremeFramework.Response;
using System.Runtime.CompilerServices;
using RestSharp.Authenticators;

namespace SupremeFramework.Tests.API
{




    [Binding]



    public class ApiTestSteps
    {

        Portal portal = new Portal();
        SupremeAPI apiConfigs = new SupremeAPI();
        private List<Dictionary<string, string>> tableData = new List<Dictionary<string, string>>();
        SupremeTable tb = new SupremeTable();



        [Given(@"the user sets the baseUrl ""([^""]*)""")]

        public void GivenTheUserSetsTheBaseUrl(string baseUrl)
        {
            SupremeAPI APIContainer = new SupremeAPI();
            apiConfigs.baseUrl = baseUrl;


            apiConfigs.client = apiConfigs.ClientWithoutAuth(apiConfigs.baseUrl);
            

           // portal.AddToAPIPortal("apiSetWithBaseUrl", apiConfigs);

        }
        [When(@"the user fetch the authentication token for the user ""([^""]*)""")]
        public void WhenTheUserFetchTheAuthenticationTokenForTheUser(string goodUserOne)
        {
            
            Users users = new Users();
            var userDict =  users.getUserCredentials(goodUserOne); 
            var username = userDict["username"];
            var password = userDict["password"];


           // token  =  getToken()


        }


        





        //   [Given(@"set client with token")]
        //  public void GivenWithToken(Table table)
        //  {
        //      tb.tableConvert(table, tableData); 
        //     foreach(var rowData in tableData)
        //    {
        //     apiConfigs.token = rowData["token"];
        //     var authenticator = apiConfigs.SetAuthToken(apiConfigs.token);
        // /    var baseUrl = apiConfigs.baseUrl;   
        //   if(baseUrl!= null) { apiConfigs.client = apiConfigs.ClientMaker(authenticator, baseUrl);


        //       portal.AddToAPIPortal("apiConfigsWithToken", apiConfigs);
        //    }


        //   break; 
        //  }



        // }


        [Given(@"the user sets a ""([^""]*)"" method")]

        public void GivenTheUserSetsTheMethod(string methodType)
        {
            var APIContainer = portal.API["apiSetWithBaseUrl"];
            APIContainer.method = APIContainer.MethodSetter(methodType);


            ///  APIContainer.payloadType = payloadType;
            
          //  portal.AddToAPIPortal("apiWithMethodSet", APIContainer);
        }

        [When(@"the user sends a payload ""([^""]*)"" of type ""([^""]*)""")]
      //  public void ThenTheUserSendsAPayloadAndItsType(string payload, string payloadType)
       // {

           // var APIContainer = portal.API["apiWithMethodSet"];

        ///    var method = APIContainer.method;
        //    if (payloadType == "path")
          //  {
        ///
         // // /     APIContainer.RequestMaker(payload, method);
           // }




       // }


        [Given(@"an API request is made")]
        public void GivenAnAPIRequestIsMade(Table table)
        {


            
            var client = apiConfigs.client;

            tb.tableConvert(table, tableData);



            foreach (var rowData in tableData)
            {
                apiConfigs.method = apiConfigs.MethodSetter(rowData["methodType"]);
                apiConfigs.urlParameter = rowData["urlParameter"];
                apiConfigs.requestBody = rowData["requestBody"];
                apiConfigs.urlResourceValue = rowData["urlResourceValue"]; 




            }

            var request = apiConfigs.RequestMaker(apiConfigs.urlParameter, apiConfigs.method);
            
            
            

            if(apiConfigs.urlResourceValue ==  "null" ) {

                var jsonContent = apiConfigs.GetJsonFileRead(apiConfigs.requestBody);

                apiConfigs.AddJsonBodyToRequest(request, jsonContent);




               // portal.AddToAPIPortal("apiSetWithAll", apiConfigs);

            }
            
            else
            { 
                apiConfigs.AddUrlSegmentToUrl(request, apiConfigs.urlParameter, apiConfigs.urlResourceValue);
                var jsonContent = apiConfigs.GetJsonFileRead(apiConfigs.requestBody);

                apiConfigs.AddJsonBodyToRequest(request, jsonContent);




              //  portal.AddToAPIPortal("apiSetWithAll", apiConfigs);

            }

            apiConfigs.request = request;
            apiConfigs.client = client; 
        }
        [When(@"the request is executed")]
        public void ThenTheRequestIsExecuted()
        {

            //    var  request = portal.API["apiSetWithAll"].request;
            //     var client = portal.API["apiSetWithAll"].client; 

            var request = apiConfigs.request; 
            var client = apiConfigs.client;
            

            var response = client.Execute(request);
            apiConfigs.response = response;


            

          //  portal.AddToAPIPortal("apiWithResponse", apiConfigs); 
            
        }

        [When(@"response is read")]
        public void ThenResponseIsRead()
        {
           /// var response = portal.API["apiWithResponse"].response;
          //  var content = response.Content;

           // var receivedInfo = JsonConvert.DeserializeObject(content); 

             
        }


        [Then(@"authenication token is saved")]
        public void ThenAuthenicationTokenIsSaved()
        {
            var response = apiConfigs.response;
           // var response = portal.API["apiWithResponse"].response;
            var content = response.Content;
            var receivedInfo = JsonConvert.DeserializeObject<AuthTokenResponse>(content);

            Console.WriteLine(receivedInfo.token); 

            apiConfigs.token = receivedInfo.token;

        }



        [Given(@"user has authenticaion token")]
        public void GivenUserHasAuthenticaionToken()
        {
            var token = apiConfigs.token;
            var authenticator = new JwtAuthenticator (token);   
            apiConfigs.client = apiConfigs.ClientMaker(authenticator, apiConfigs.baseUrl); 
            var client = apiConfigs.client;
             





        }

        [Then(@"the GetResponsforCatalogItem is received")]
        public void ThenTheGetResponsforCatalogItemIsReceived()
        {
            var response = apiConfigs.response; 

            var content = response.Content;

            var receivedInfo = JsonConvert.DeserializeObject<GetCatalogItemIdResp>(content);

            Console.WriteLine(receivedInfo.catalogItem.id); 
            

        }



    }

}