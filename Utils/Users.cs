using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SupremeFramework.Utils
{
     public class Users
    {


        public IDictionary<string,string> getUserCredentials (string username)
        {

            switch (username){
                case "GoodUserOne": 


                    var credentials = new Dictionary<string, string>
                  {
                    { "username", "admin@microsoft.com" },
                    { "password", "Pass@word1" }
                };
                    return credentials;


                case "BadUserOne":


                var cred = new Dictionary<string, string>
                  {
                    { "username", "Baddemouser@microsoft.com" },
                    { "password", "BadPass@word1" }
                };
                return cred;


            default: throw new ArgumentException("Invalid Username");
            }
        }




    }

}
