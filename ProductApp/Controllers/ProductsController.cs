using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product{ Id=1,Name="Tomato Soup",Category="Grocerie",Price=1},
            new Product{ Id=2,Name="Yo-yo",Category="Toys",Price=3.75M},
            new Product{ Id=3,Name="Hammer",Category="Hardware",Price=16.99M}

        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public HttpResponseMessage Get()
        {
            // Write the list to the response body.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, products);
            return response;
        }

        public async Task<IHttpActionResult> GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
