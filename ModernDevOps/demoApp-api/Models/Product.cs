using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoApp_api.Models
{
    public class Product
    {
        [JsonProperty(PropertyName = "ProductName")]
        public string ProductName { get; set; }

        [JsonProperty(PropertyName = "ProductID")]
        public int ProductID { get; set; }

        [JsonProperty(PropertyName = "InStock")]
        public int InStock { get; set; }

        [JsonProperty(PropertyName = "ProductImg")]
        public string ProductImg { get; set; }
        
    }
}