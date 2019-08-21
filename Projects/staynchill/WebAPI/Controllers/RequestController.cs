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

namespace WebAPI.Controllers
{
    [RoutePrefix("api/request")]
    public class RequestController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        [Registered]
        public IHttpActionResult Post(Request request)
        {
            var requestManager = new RequestManagement();
            requestManager.Create(request);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }


        public IHttpActionResult Get()
        {
            var requestManager = new RequestManagement();
            apiResponse = new ApiResponse();
            var requests = requestManager.RetrieveAll();
            apiResponse.Data = requests;
            return Ok(apiResponse);
        }

        [Modified]
        public IHttpActionResult Put(Request request)
        {
            var requestManager = new RequestManagement();
            requestManager.Update(request);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }

        [HttpPost]
        [Route("hotel")]
        public IHttpActionResult Post2(Request request)
        {
            var requestManager = new RequestManagement();
            List<Request> id = requestManager.RetrieveIdByHotel(request);
            apiResponse = new ApiResponse();
            apiResponse.Data = id;
            return Ok(apiResponse);
        }
    }
}
