using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Bitacoras;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    [RoutePrefix("api/productocarrito")]
    public class ProductoCarritoController : ApiController
    {
        

        ApiResponse apiResponse = new ApiResponse();

        [HttpPost]
        [Route("GetByCar")]
        public IHttpActionResult Post2(ProductoCarrito prod)
        {
            var productoCarritoManager = new ProductoCarritoManagement();
            apiResponse = new ApiResponse();
            var productos = productoCarritoManager.RetrieveAllByUser(prod.FkCarrito);
            apiResponse.Data = productos;
            return Ok(apiResponse);
        }

        [Registered]
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(ArrayProductos arrayProductos)
        {
            try
            {

                var productoCarritoManager = new ProductoCarritoManagement();
                productoCarritoManager.CreateList(arrayProductos);
                apiResponse = new ApiResponse();

                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPost]
        [Route("SendEmail")]
        public async Task<IHttpActionResult> Post(ArrayProductosWithCorreo datos)
        {
            try
            {

                var productoCarritoManager = new ProductoCarritoManagement();
                var userManager = new UserManagement();
                var hotelManagement = new HotelManagement();
                List<ProductoCarrito> productos = datos.productsArray;
                User tmpUser = new User { Correo = datos.correo };
                User user = userManager.RetrieveByCorreo(tmpUser);
                CommissionHotel hotel = hotelManagement.getCommision(datos.hotel);
                
                await productoCarritoManager.SendEmailCart(productos, user, hotel);
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