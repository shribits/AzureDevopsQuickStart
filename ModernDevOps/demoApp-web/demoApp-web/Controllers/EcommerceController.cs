using Inspinia_MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebDemo;
using WebDemo.Models;

namespace Inspinia_MVC5.Controllers
{
    public class EcommerceController : Controller
    {
        ProductEditViewModel productEditViewModel;
        WebDemoClient webClient;
        List<ProductCategory> productCats;

        public EcommerceController()
        {
            productCats = new List<ProductCategory>();
            webClient = new WebDemoClient();
            productEditViewModel = new ProductEditViewModel();

        } 

        //public ActionResult ProductCategoryById(string id)
        //{
        //    ProductCategory productCat = webClient.Products.GetById(id);
        //    return View();
        //}

        public ActionResult ProductCategory()
        {
            productCats = webClient.Products.Get().ToList();
            return View(productCats);
        }

        public ActionResult ProductEdit()
        {
            productCats = webClient.Products.Get().ToList();
            foreach(var item in productCats)
                productEditViewModel.productCategory.Add(item);
            //webClient.Products.Post(productCat);
            return View(productEditViewModel);
        }

        public ActionResult CreateProductCat(ProductEditViewModel Productcategory)
        {
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult CreateProduct(ProductEditViewModel ViewProductcategory)
        {
            var newProductcat = new ProductCategory();
            foreach (var item in productCats)
            {
                if (string.Equals(item.ProductCat, ViewProductcategory.productCategoryName))
                    item.Products.Add(new Product { ProductImg = ViewProductcategory.productImg, InStock = ViewProductcategory.inStock, ProductName = ViewProductcategory.productName });
                webClient.Products.Put((int)item.ProductCatID,item.ToString());
            }
            
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Orders()
        {
            return View();
        }

    }
}