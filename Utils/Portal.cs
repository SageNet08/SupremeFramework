using RestSharp;
using SupremeFramework.APIConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremeFramework.Utils
{
    public class Portal
    {

        public Dictionary<string, SupremeAPI> API = new Dictionary<string, SupremeAPI>();
        public Dictionary<string, RestRequest> RequestPortal = new Dictionary<string, RestRequest>();
        public Portal() { 
        
        
        
        }


        public void AddToAPIPortal(string Tname, SupremeAPI value)
        {
            API.Add(Tname, value);
        }

    }
}
