using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemo.Models;

namespace Inspinia_MVC5.ViewModels
{
    public class ProductEditViewModel
    {
        public List<ProductCategory> productCategory { get; set; }
        public string productCategoryName { get; set; }
        public string productName { get; set; }
        public int inStock { get; set; }
        public string productImg { get; set; }
        public ProductEditViewModel()
        {
            productCategory = new List<ProductCategory>();
        }
    }
}