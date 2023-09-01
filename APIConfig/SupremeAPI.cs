using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;
using RestSharp;
using RestSharp.Authenticators;

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
            if (urlParameter == "")
            {
                var request = new RestRequest(urlParamter, method);
                return request;
            }

            else
            {
                var request = new RestRequest("{ " + urlParamter + " }", method);
                return request;

            }



        }

        public void AddUrlSegmentToUrl(RestRequest request, string parameterID, string resource)
        {
            request.AddUrlSegment(parameterID, resource); 

        }


        public void AddJsonBodyToRequest(RestRequest request, string jsonContent)
        {
            request.AddJsonBody(jsonContent);
        } 


        public string GetJsonFileRead(string jsonFileName)
        {
            string jsonFilePath = "C:\\Users\\P12AE86\\source\\repos\\SpecflowAPI\\JSON Files\\";
            string fullPath = jsonFilePath + jsonFilePath + ".json"; 

            string jsonContent = File.ReadAllText(jsonFilePath);
            return jsonContent;
        }


        public JwtAuthenticator SetAuthToken(string token)
        {
            var authenticator = new JwtAuthenticator(token);
            return authenticator;
        }

        public RestClient ClientMaker(JwtAuthenticator authenticator, string baseurl)
        {
            var options = new RestClientOptions()
            {
                Authenticator = authenticator
            };

            var client = new RestClient(options);
            return client;
        }
    }
}
