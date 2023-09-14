using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Gherkin.CucumberMessages.Types;
using LivingDoc.Dtos;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using SupremeFramework.Utils;

namespace SupremeFramework.APIConfig
{
    public class SupremeAPI
    {

        public string? baseUrl { get; set; }
        public Method method { get; set; }

        public string? payloadType { get; set; }

        public string urlParameter { get; set; } 

        public string requestBody { get; set; }
        public string urlResourceValue { get; set; }

        public RestRequest request {  get; set; }
        public RestClient client { get; set; }

        public RestResponse response { get; set; }

        public string? token { get; set; }
      
        public Method MethodSetter(string methodType)
        {
            switch (methodType)
            {
                case "GET": return Method.Get; 
                case "POST": return Method.Post;
                case "PUT": return Method.Put; 
                case "DELETE": return Method.Delete;
                default: Console.WriteLine("Wrong Method Name");
                    throw new ArgumentException("Invalid methodType: " + methodType);
            }
        }

        
        public void payloadSetter(string payloadType)
        {
            if (payloadType == "path")
            {

                setPath(); 
            }

            var a = new RestRequest();

        }

        

        public void setPath() 
        { 
        
        }



        public RestRequest RequestMaker(string urlParamter, Method method)
        {
            //if (urlParameter == "")
         //   {
                var request = new RestRequest(urlParamter, method);
                return request;
           // }

          //  else
        //    {
         //       var request = new RestRequest("{ " + urlParamter + " }", method);
         //       return request;

        //    }



        }

        public void AddUrlSegmentToUrl(RestRequest request, string parameterID, string resource)
        {

            string pattern = @"\{([^}]+)\}";
            Match match = Regex.Match(parameterID, pattern);
            if (match.Success)
            {
                string matchedPart = match.Groups[1].Value; // Extract the content inside curly braces
                

                request.AddUrlSegment(matchedPart, resource);
            }
            else
            {
                Console.WriteLine("Pattern not found in the input string.");
            }


            

        }


        public void AddJsonBodyToRequest(RestRequest request, string jsonContent)
        {
            request.AddJsonBody(jsonContent);
        }
        public string GetJsonFileRead(string jsonFileName)
        {
       


            string jsonFilePath = "C:\\Users\\P12AE86\\Source\\Repos\\SageNet08\\SupremeFramework\\Request\\Json\\";
            string fullPath = jsonFilePath + jsonFileName + ".json"; 

            string jsonContent = File.ReadAllText(fullPath);
            return jsonContent;
        }


        public JwtAuthenticator SetAuthToken(string token)
        {
            var authenticator = new JwtAuthenticator(token);
            return authenticator;
        }

        public RestClient ClientMaker(string token,  string baseurl)
        {
         
            var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer");
            var options = new RestClientOptions(baseurl)
            {
                Authenticator = authenticator
            };
         

            var client = new RestClient(options);
            return client;
        }

        public RestClient ClientWithoutAuth(string baseurl)
        { return new RestClient(baseurl); }
    }
}
