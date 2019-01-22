using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using demoApp_api.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace demoApp_api.Controllers
{
    public class ProductsController : ApiController
    {

        private string EndpointUrl = "https://db-aus-dev-productcat.documents.azure.com:443/";
        private string PrimaryKey = "0O9LfvJmV5Y2bI5rUKDsoHzm3nRJ27BtqRypndVWHIbBeALnO4FqlJX5UYxWpvKW7lKQKZU7fifrrMY8IkdHmg==";
        private DocumentClient client;

        // GET: api/Products
        public IEnumerable<ProductCategory> Get()
        {
            return ExecuteSimpleQuery("sqlCollection", "sql");
        }

        // GET: api/Products/5
        [System.Web.Http.Route("~/Products/GetById")]
        public IHttpActionResult GetById(string id)
        {
            //ExecuteSimpleQuery("sqlCollection", "sql");
            //return "value";
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            // Set some common query options
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            // Here we find the Product Category via its Name
            IQueryable<ProductCategory> ProductQuery = this.client.CreateDocumentQuery<ProductCategory>(
                    UriFactory.CreateDocumentCollectionUri("sqlCollection", "sql"), queryOptions).Where(f => f.ProductCatID == Convert.ToInt32(id));

            // The query is executed synchronously here, but can also be executed asynchronously via the IDocumentQuery<T> interface
            List<ProductCategory> productCategories = new List<ProductCategory>();
            ProductCategory result = new ProductCategory();
            foreach (ProductCategory productCat in ProductQuery)
            {
                result = productCat;
                break;
            }
            if (result.ProductCatID==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]ProductCategory prodCat)
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            
            try
            {
                client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("sqlCollection", "sql"), prodCat);
            }
            catch (Exception de)
            {
                return NotFound();
                
            }
            return Ok();


        }

        // PUT: api/Products/5
        public IHttpActionResult Put([FromBody]ProductCategory prodCat)
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);

            try
            {
                client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri("sqlCollection", "sql"), prodCat);
            }
            catch (Exception de)
            {
                return NotFound();

            }
            return Ok();
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
        private List<ProductCategory> ExecuteSimpleQuery(string databaseName, string collectionName)
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            // Set some common query options
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            // Here we find the Product Category via its Name
            IQueryable<ProductCategory> ProductQuery = this.client.CreateDocumentQuery<ProductCategory>(
                    UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions);

            
            // The query is executed synchronously here, but can also be executed asynchronously via the IDocumentQuery<T> interface
            List<ProductCategory> productCategories = new List<ProductCategory>();

            if (ProductQuery.ToList().Count()!=0)
            {
                foreach (ProductCategory productCat in ProductQuery)
                {
                    productCategories.Add(productCat);
                }
                return productCategories;
            }
            else
            {
                return null;
            } 

        }
    }
}
