using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UserReservationController : ApiController
    {

        ApiResponse apiResponse = new ApiResponse();

        public IHttpActionResult Get(int id)
        {
            var urManager = new UserReservationManagement();
            var ur = new UserReservation() { Id = id };
            ur = urManager.RetrieveById(ur);
            apiResponse = new ApiResponse();
            apiResponse.Data = ur;
            return Ok(apiResponse);
        }
    }
}