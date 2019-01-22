using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using demoApp_api.Controllers;
using demoApp_api.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Results;

namespace demoApp_api.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllProducts()
        {
            ProductsController controller = new ProductsController();
            IEnumerable<ProductCategory> result = controller.Get();
            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void PostNewProdCat()
        {
            // Arrange
            ProductsController controller = new ProductsController();


            ProductCategory newProd = new ProductCategory();
            newProd.ProductCat = "Test2";
            newProd.ProductCatID = 123;


            // Act
            var response = controller.Post(newProd);

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkResult));
            
        }
        [TestMethod]
        public void UpdateProdCat()
        {
            // Arrange
            ProductsController controller = new ProductsController();


            ProductCategory newProd = new ProductCategory();
            newProd.ProductCat = "Test4";
            newProd.ProductCatID = 123;
            newProd.id = new Guid("5bfda90a-7461-4e05-b4c5-a72adcde4568");


            // Act
            var response = controller.Put(newProd);

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }
    }
}
