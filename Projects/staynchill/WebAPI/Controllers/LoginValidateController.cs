using Core;
using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    [RoutePrefix("api/loginvalidate")]
    public class LoginValidateController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        // LOGIN api/user/code/name
        public IHttpActionResult Post(User user)
        {

            try
            {
                var userManagement = new UserManagement();
                var loginUser = userManagement.Login(user);
                apiResponse = new ApiResponse();
                apiResponse.Data = loginUser;

                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPost]
        [Route("ischeckedin")]
        public IHttpActionResult IsCheckedIn(User user)
        {

            try
            {
                var userManagement = new UserManagement();
                var loginUser = userManagement.Login(user);
                apiResponse = new ApiResponse();
                apiResponse.Data = loginUser;

                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}