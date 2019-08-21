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

namespace API.Controllers
{
    [RoutePrefix("api/roomtype")]
    public class RoomTypeController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        [HttpGet]
        [Route("GetByHotel")]
        public IHttpActionResult Get(int id)
        {
            var typeManager = new RoomTypeManagement();

            apiResponse = new ApiResponse();
            var types = typeManager.RetrieveAllById(id);
            apiResponse.Data = types;

            return Ok(apiResponse);
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var typeManager = new RoomTypeManagement();

            apiResponse = new ApiResponse();
            var types = typeManager.RetrieveAll();
            apiResponse.Data = types;

            return Ok(apiResponse);
        }

        //public IHttpActionResult Get(RoomType type)
        //{
        //    var typeManager = new RoomTypeManagement();
        //    type = typeManager.RetrieveById(type);
        //    apiResponse = new ApiResponse();
        //    apiResponse.Data = type;

        //    return Ok(apiResponse);
        //}

        [HttpPost]
        [Registered]
        [Route("")]
        public IHttpActionResult Post(RoomType tipo)
        {
            tipo.Id = 1;
            tipo.State = "Enabled";
            var typeManager = new RoomTypeManagement();
            typeManager.Create(tipo);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }

        [HttpPut]
        [Modified]
        [Route("")]
        public IHttpActionResult Put(RoomType tipo)
        {
            tipo.State = "Enabled";
            var typeManager = new RoomTypeManagement();
            typeManager.Update(tipo);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }

        [HttpDelete]
        [Deleted]
        [Route("")]
        public IHttpActionResult Delete(RoomType tipo)
        {
            var typeManager = new RoomTypeManagement();
            typeManager.Delete(tipo);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);

        }
    }
}
