using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Bitacoras;
using Exceptions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/hotel")]
    public class HotelController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        [HttpPost]
        [Route("")]
        [Registered]
        public IHttpActionResult Post (Hotel hotel)
        {

            try {
                var hotelManager = new HotelManagement();
                hotelManager.Create(hotel);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpDelete]
        [Route("")]
        [Deleted]
        public IHttpActionResult Delete(Hotel hotel)
        {
            var hotelManager = new HotelManagement();

            var vHotel = hotelManager.RetrieveById(hotel);

            if (vHotel == null)
            {
                return InternalServerError();
            }
            else
            {
                hotelManager.Delete(hotel);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
        }

        [HttpPut]
        [Route("")]
        [Modified]
        public IHttpActionResult Put(Hotel hotel)
        {
            hotel.RequestState = "N/A";
            hotel.State = "N/A";
            hotel.Type = "N/A";
            hotel.Date = DateTime.Now;

            var hotelManager = new HotelManagement();

            var vHotel = hotelManager.RetrieveById(hotel);

            if (vHotel == null)
            {
                return InternalServerError();
            }
            else
            {
                hotelManager.Update(hotel);
                var rHotel = hotelManager.RetrieveById(hotel);
                apiResponse = new ApiResponse
                {
                    Data = rHotel
                };
                return Ok(apiResponse);
            }
        }

        [HttpGet]
        [Route("getCommission")]
        public IHttpActionResult GetId(int hotel)
        {
            var hotelManager = new HotelManagement();
            apiResponse = new ApiResponse();
            var hotels = hotelManager.getCommision(hotel);
            apiResponse.Data = hotels;
            return Ok(apiResponse);
        }

        public IHttpActionResult Get()
        {
            var hotelManager = new HotelManagement();
            apiResponse = new ApiResponse();
            var hotels = hotelManager.RetrieveAll();
            apiResponse.Data = hotels;
            return Ok(apiResponse);
        }

        [HttpGet]
        [Route("administrador")]
        public IHttpActionResult GetAll()
        {
            var hotelManager = new HotelManagement();
            apiResponse = new ApiResponse();
            var hotels = hotelManager.RetrieveAllAdministrador();
            apiResponse.Data = hotels;
            return Ok(apiResponse);
        }

        [HttpPost]
        [Route("GetById")]
        public IHttpActionResult Post2(User user)
        {
            var hotelManager = new HotelManagement();
            apiResponse = new ApiResponse();
            var hotels = hotelManager.RetrieveAllByUser(user.Id.ToString());
            apiResponse.Data = hotels;
            return Ok(apiResponse);
        }

        [HttpPost]
        [Route("AsociarHotelAdmin")]
        public IHttpActionResult Post3(Hotel hotel)
        {
            var hotelManager = new HotelManagement();
            apiResponse = new ApiResponse();
            hotelManager.AsociarHotelAdmin(hotel.Id, hotel.Email);
            return Ok(apiResponse);
        }

        [HttpPost]
        [Route("filtrar")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Post3Async(HotelFiltro hotelFiltro)
        {
            var hotelManager = new HotelManagement();
            apiResponse = new ApiResponse();
            var hotels = await hotelManager.RetrieveAllByFiltroV2(hotelFiltro);
            apiResponse.Data = hotels;
            return Ok(apiResponse);
        }

        [HttpPost]
        [Route("SendMembershipEmail")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Post4Async(Hotel hotel)
        {
            var hotelManager = new HotelManagement();
            var userManager = new UserManagement();
            apiResponse = new ApiResponse();
            decimal totalPrice = hotel.DailySales;
            CommissionHotel commissionHotel = hotelManager.getCommision(hotel.Id);
            User tmpUser = new User() { Correo = hotel.Email };
            User user = userManager.RetrieveByCorreo(tmpUser);
            await hotelManager.SendMembershipEmail(commissionHotel, user, totalPrice);
            return Ok(apiResponse);
        }
    }
}