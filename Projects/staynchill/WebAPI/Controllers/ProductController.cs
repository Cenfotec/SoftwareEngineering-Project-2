using Core;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace API.Controllers
{
    /// <summary>
    ///
    /// </summary>
    /// 
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
           
        ApiResponse apiResponse = new ApiResponse();

        /// <summary>
        /// RETRIEVE api/product
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var productoManager = new ProductManagement();
            apiResponse = new ApiResponse();
            List<Product> products = productoManager.RetrieveAll();
            apiResponse.Data = products;
            return Ok(apiResponse);
        }

        /// <summary>
        /// RETRIEVE by ID api/product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(string id)
        {
            var productoManager = new ProductManagement();
            var product = new Product() { Code = id };
            product = productoManager.RetrieveById(product);
            apiResponse = new ApiResponse();
            apiResponse.Data = product;
            return Ok(apiResponse);
        }

        // CREATE api/product (body)
        public IHttpActionResult Post(Product product)
        {
            var productoManager = new ProductManagement();
            productoManager.Create(product);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }

        // UPDATE api/product
        public IHttpActionResult Put(Product product)
        {
            var productoManager = new ProductManagement();
            productoManager.Update(product);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }

        // DELETE api/product/id
        public IHttpActionResult Delete(Product product)
        {
            var productoManager = new ProductManagement();
            productoManager.Delete(product);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }
    }
}
