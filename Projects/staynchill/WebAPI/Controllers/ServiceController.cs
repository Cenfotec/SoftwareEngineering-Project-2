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
    [RoutePrefix("api/service")]
    public class ServiceController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        [HttpPost]
        [Route("")]
        [Registered]
        public IHttpActionResult Post(Service service)
        {
            service.State = "Enabled";
            var serviceManager = new ServiceManagement();
            serviceManager.Create(service);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }

        [HttpPost]
        [Route("GetByHotel")]
        public IHttpActionResult Post2(Hotel hotel)
        {
            var serviceManager = new ServiceManagement();
            apiResponse = new ApiResponse();
            var services = serviceManager.RetrieveAllByHotel(hotel.Id);
            apiResponse.Data = services;
            return Ok(apiResponse);
        }

        [HttpDelete]
        [Route("")]
        [Deleted]
        public IHttpActionResult Delete(Service service)
        {
            var serviceManager = new ServiceManagement();
            serviceManager.Delete(service);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }

        [HttpPut]
        [Route("")]
        [Modified]
        public IHttpActionResult Put(Service service)
        {
            service.State = "Enabled";
            var serviceManager = new ServiceManagement();

                serviceManager.Update(service);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
        }
    }
}