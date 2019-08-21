using Core;
using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Bitacoras;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/producto")]
    public class ProductoController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        [Registered]
        public IHttpActionResult Post(Producto producto)
        {
            try
            {
                
                var productoManager = new ProductoManagement();
                productoManager.Create(producto);
                apiResponse = new ApiResponse();

                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        // RETRIEVE api/producto/id
        [Route("GetProductsByHotelServicio/{idHotel}/{idService}")]
        public IHttpActionResult Get(string idHotel, string idService)
        {
            try
            {
                var productoManager = new ProductoManagement();
                apiResponse = new ApiResponse();
                var products = productoManager.GetRetriveAllByHotelServicioStatement(Int32.Parse(idHotel), Int32.Parse(idService));
                apiResponse.Data = products;
                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        // UPDATE api/producto
        [Modified]
        public IHttpActionResult Put(Producto producto)
        {
            try
            {
                if (producto.Value == null)
                {
                    producto.Value = "N/A";
                }
                var productoManager = new ProductoManagement();
                productoManager.Update(producto);
                apiResponse = new ApiResponse();

                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        // DELETE api/producto/id
        [Deleted]
        public IHttpActionResult Delete(Producto producto)
        {
            try
            {
                var productoManager = new ProductoManagement();
                productoManager.Delete(producto);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}