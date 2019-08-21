using Core;
using CoreAPI;
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
    [RoutePrefix("api/common")]
    public class CommonController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        public IHttpActionResult Get()
        {
            var commonManager = new CommonManagement();
            apiResponse = new ApiResponse();
            List<Common> commons = commonManager.RetrieveAll();
            apiResponse.Data = commons;
            return Ok(apiResponse);
        }
    }
}
