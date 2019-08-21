using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UbicationController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        public IHttpActionResult Post(Ubication ubication)
        {
            var hotelManager = new UbicationManagement();
            hotelManager.Create(ubication);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }

        public IHttpActionResult Get()
        {
            var hotelManager = new UbicationManagement();
            apiResponse = new ApiResponse();
            var ubications = hotelManager.RetrieveAll();
            apiResponse.Data = ubications;
            return Ok(apiResponse);
        }
    }
}