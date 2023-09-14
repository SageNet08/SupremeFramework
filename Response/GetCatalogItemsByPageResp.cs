using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremeFramework.Response
{
    public class GetCatalogItemsByPageResp
    {

       
       
       public int pageCount { get; set; }
       

        
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public double price { get; set; }
            public string pictureUri { get; set; }
            public int catalogTypeId { get; set; }
            public int catalogBrandId { get; set; }
       





    }
}
