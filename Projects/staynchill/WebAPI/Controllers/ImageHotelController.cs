using System;
using Entities_POJO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using CoreAPI;

namespace WebAPI.Controllers
{
    public class ImageHotelController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        public IHttpActionResult Post(ImageHotel hotel)
        {
            var imageManager = new ImageHotelManagement();
            imageManager.Create(hotel);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }
    }
}
