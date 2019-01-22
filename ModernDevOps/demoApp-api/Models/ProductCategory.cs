using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoApp_api.Models
{
    public class ProductCategory
    {
        [JsonProperty(PropertyName = "ProductCat")]
        public string ProductCat { get; set; }

        [JsonProperty(PropertyName = "ProductCatID")]
        public int ProductCatID { get; set; }

        [JsonProperty(PropertyName = "Products")]
        public Product[] Products { get; set; }

        [JsonProperty(PropertyName = "ProductCatImg")]
        public string ProductCatImg { get; set; }

        public Guid id { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}