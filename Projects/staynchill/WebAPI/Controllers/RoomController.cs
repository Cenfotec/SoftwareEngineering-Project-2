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
    public class RoomController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();


        public IHttpActionResult Get(int id)
        {
            var roomManager = new RoomManagement();

            var rooms = roomManager.RetrieveAllById(id);
            apiResponse = new ApiResponse();
            apiResponse.Data = rooms;

            return Ok(apiResponse);
        }

        [Registered]
        public IHttpActionResult Post(Room room)
        {
            try { 
            var roomManager = new RoomManagement();
            roomManager.Create(room);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
            } catch(BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Get()
        {
            var roomManager = new RoomManagement();

            apiResponse = new ApiResponse();
            var rooms = roomManager.RetrieveAll();
            apiResponse.Data = rooms;

            return Ok(apiResponse);
        }


        [Modified]
        public IHttpActionResult Put(Room room)
        {
            if (room.Value == null)
            {
                room.Value = "N/A";
            }
            room.RoomTypeName = "N/A";
            room.Type = "Habitación";
            var roomManager = new RoomManagement();
            roomManager.Update(room);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }

        [Deleted]
        public IHttpActionResult Delete(Room room)
        {
            var roomManager = new RoomManagement();
            roomManager.Delete(room);
            apiResponse = new ApiResponse();
            return Ok(apiResponse);
        }

    }


}
