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
using System.Net;
using NUnit.Framework;
using Gherkin;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow.Tracing;
using System.ComponentModel.DataAnnotations;
using SupremeFramework.Features.API;

namespace SupremeFramework.Tests.API
{




    [Binding]



    public class ApiTestSteps
    {


        SupremeAPI apiConfigs = new SupremeAPI();
        private List<Dictionary<string, string>> tableData = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> tableData2 = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> tableData3 = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> tableData4 = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> tableData5 = new List<Dictionary<string, string>>();
        SupremeTable tb = new SupremeTable();



        [Given(@"the user sets the baseUrl ""([^""]*)""")]

        public void GivenTheUserSetsTheBaseUrl(string baseUrl)
        {
            SupremeAPI APIContainer = new SupremeAPI();
            apiConfigs.baseUrl = baseUrl;


            apiConfigs.client = apiConfigs.ClientWithoutAuth(apiConfigs.baseUrl);
            


        }
        
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


          


            if (apiConfigs.urlResourceValue ==  "null" ) {

                var jsonContent = apiConfigs.GetJsonFileRead(apiConfigs.requestBody);

                apiConfigs.AddJsonBodyToRequest(request, jsonContent);




              

            }
            
            else
            { 
                apiConfigs.AddUrlSegmentToUrl(request, apiConfigs.urlParameter, apiConfigs.urlResourceValue);
                var jsonContent = apiConfigs.GetJsonFileRead(apiConfigs.requestBody);

                apiConfigs.AddJsonBodyToRequest(request, jsonContent);

               


            }

            apiConfigs.request = request;
            apiConfigs.client = client; 
        }
        [When(@"the request is executed")]
        public void ThenTheRequestIsExecuted()
        {
            var request = apiConfigs.request; 
            var client = apiConfigs.client;
            

            var response = client.Execute(request);
            apiConfigs.response = response;

            
            if (apiConfigs.response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Request Successful");
            }
            else
            {
                Console.WriteLine("Status Code: ", apiConfigs.response.StatusCode);
            }





        }



        [Then(@"authenication token is saved")]
        public void ThenAuthenicationTokenIsSaved()
        {
            var response = apiConfigs.response;

            var content = response.Content;
            var receivedInfo = JsonConvert.DeserializeObject<AuthTokenResponse>(content);

            Console.WriteLine(receivedInfo.token); 

            apiConfigs.token = receivedInfo.token;

        }



        [Given(@"user has authenticaion token")]
        public void GivenUserHasAuthenticaionToken()
        {
            var token = apiConfigs.token;
           



            apiConfigs.client = apiConfigs.ClientMaker(token, apiConfigs.baseUrl); 
            var client = apiConfigs.client;
            
            var request = apiConfigs.request;

            



        }
        [Then(@"the ""([^""]*)"" type is received")]
        public void ThenTheRequiredContentIsReceived(string targetType)
        {
            var response = apiConfigs.response; 
            string namespacew = "SupremeFramework.Response.";
            string full = namespacew + targetType;
            Type? type = Type.GetType(full);

            var content = response.Content;
            Console.WriteLine(content);

            

            if (type != null)
            {
                var receivedInfo = JsonConvert.DeserializeObject(content, type);
                
               // Console.WriteLine(((GetCatalogItemIdResp)receivedInfo).catalogItem.id);
                Console.WriteLine(content);
            }


        }

        [Then(@"the Status Code ""([^""]*)"" should be received")]
        public void ThenTheStatusCodeShouldBeReceived(int statusCode)
        {
            HttpStatusCode stringCode = apiConfigs.response.StatusCode;
            int intCode = (int)stringCode;
            Console.WriteLine(intCode);
            Assert.AreEqual(statusCode, intCode);
            var response = apiConfigs.response;
            var headers = response.Headers;


            if (apiConfigs.response.StatusCode == HttpStatusCode.OK)
            {
                // Access the response headers and verify a specific header
                if (headers != null)
                {

                    Dictionary<string, string> HeadersList = new Dictionary<string, string>();
                    foreach(var item in response.Headers)
                    {
                        string[]KeyPairs = item.ToString().Split('=');
                        HeadersList.Add(KeyPairs[0], KeyPairs[1]);


                        Console.WriteLine($"The value of Your-Header-Name is: {KeyPairs[0]}, {KeyPairs[1]}");
                        


                    }



                    
                }

                
            }
            else
            {
                Console.WriteLine($"Request failed with status code: {response.StatusCode}");
            }


        }



        [Given(@"the user adds query parameters to the request")]
        public void GivenTheUserAddsQueryParametersToTheRequest(Table table)
        {
            var request = apiConfigs.request;

            tb.tableConvert(table, tableData2);
            foreach (var rowData in tableData2)
            {
                string key = rowData["key"];
                int value = int.Parse(rowData["value"]);

                request.AddQueryParameter(key, value);



            }
        }


        [Then(@"the response is verified for the following fields")]
        public void ThenTheResponseIsVerifiedForTheFollowingFields(Table table)
        {
            var response = apiConfigs.response;
            var content = response.Content;
            tb.tableConvert(table, tableData3);
            var receivedInfo = JsonConvert.DeserializeObject<GetCatalogItemIdResp>(content);
            foreach (var rowData in tableData3)
            {
                int id  = int.Parse(rowData["id"]);
                string name = rowData["name"];
                double price = double.Parse(rowData["price"]); 
                string uri = rowData["pictureUri"];
                int catalogTypeId = int.Parse(rowData["catalogTypeId"]);
                int catalogBrandId = int.Parse(rowData["catalogBrandId"]);

                Assert.AreEqual(id, receivedInfo.catalogItem.id);
                Assert.AreEqual(price, receivedInfo.catalogItem.price);
                Assert.AreEqual(name, receivedInfo.catalogItem.name);
                Assert.AreEqual(uri, receivedInfo.catalogItem.pictureUri);
                Assert.AreEqual(catalogBrandId, receivedInfo.catalogItem.catalogBrandId);
                Assert.AreEqual(catalogTypeId, receivedInfo.catalogItem.catalogTypeId); 



            }
        }

        [Then(@"the DELETE response is verified for the following field")]
        public void ThenTheDELETEResponseIsVerifiedForTheFollowingField(Table table)
        {

            var response = apiConfigs.response;
            var content = response.Content;
            tb.tableConvert(table, tableData4);
            var receivedInfo = JsonConvert.DeserializeObject<DeleteCatalogIdResponse>(content);
            foreach (var rowData in tableData4)
            {
                string stats  = rowData["status"];
              
                Assert.AreEqual(stats, receivedInfo.status);
             


            }



        }

        [Then(@"the Get response is verified for the following field")]
        public void ThenThePUTResponseIsVerifiedForTheFollowingField(Table table)
        {
            var response = apiConfigs.response;
            var content = response.Content;
            tb.tableConvert(table, tableData3);
            var receivedInfo = JsonConvert.DeserializeObject<GetCatalogItemsByPageResp>(content);
            foreach (var rowData in tableData5)
            {
                int id = int.Parse(rowData["id"]);
                string name = rowData["name"];
                double price = double.Parse(rowData["price"]);
                string uri = rowData["pictureUri"];
                int catalogTypeId = int.Parse(rowData["catalogTypeId"]);
                int catalogBrandId = int.Parse(rowData["catalogBrandId"]);
                int PageCount = int.Parse(rowData["pageCount"]);
                Assert.AreEqual(id, receivedInfo.id);
                Assert.AreEqual(price, receivedInfo.price);
                Assert.AreEqual(name, receivedInfo.name);
                Assert.AreEqual(uri, receivedInfo.pictureUri);
                Assert.AreEqual(catalogBrandId, receivedInfo.catalogBrandId);
                Assert.AreEqual(catalogTypeId, receivedInfo.catalogTypeId);
                Assert.AreEqual(PageCount, receivedInfo.pageCount);


            }
        }


        [Then(@"the GetRequestByPage type is received")]
        public void ThenTheGetRequestByPageTypeIsReceived()
        {
            var response = apiConfigs.response;
            var content = response.Content;


            var receivedInfo = JsonConvert.DeserializeObject<GetCatalogItemsByPageResp>(content);

            Console.WriteLine(content);

        }

        [Then(@"the GetByPage response is verified for the following field")]
        public void ThenTheGetByPageResponseIsVerifiedForTheFollowingField(Table table)
        {
            var response = apiConfigs.response;
            var content = response.Content;
            tb.tableConvert(table, tableData3);
            var receivedInfo = JsonConvert.DeserializeObject<GetCatalogItemsByPageResp>(content);
            foreach (var rowData in tableData5)
            {
                int id = int.Parse(rowData["id"]);
                string name = rowData["name"];
                double price = double.Parse(rowData["price"]);
                string uri = rowData["pictureUri"];
                int catalogTypeId = int.Parse(rowData["catalogTypeId"]);
                int catalogBrandId = int.Parse(rowData["catalogBrandId"]);
                int PageCount = int.Parse(rowData["pageCount"]);
                Assert.AreEqual(id, receivedInfo.id);
                Assert.AreEqual(price, receivedInfo.price);
                Assert.AreEqual(name, receivedInfo.name);
                Assert.AreEqual(uri, receivedInfo.pictureUri);
                Assert.AreEqual(catalogBrandId, receivedInfo.catalogBrandId);
                Assert.AreEqual(catalogTypeId, receivedInfo.catalogTypeId);
                Assert.AreEqual(PageCount, receivedInfo.pageCount);


            }
        }






    }

}