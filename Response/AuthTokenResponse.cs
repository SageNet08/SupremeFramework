using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremeFramework.Response
{
    public class AuthTokenResponse
    {

       
            public bool result { get; set; }
            public string? token { get; set; }
            public string? username { get; set; }
            public bool isLockedOut { get; set; }
            public bool isNotAllowed { get; set; }
            public bool requiresTwoFactor { get; set; }
    }





    
}
