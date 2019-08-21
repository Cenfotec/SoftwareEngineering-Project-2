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
    [RoutePrefix("api/forgotpassword")]
    public class ForgotPasswordController : ApiController
    {

        ApiResponse apiResponse = new ApiResponse();

        // CREATE api/code
        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync(User user)
        {
            try
            {
                var userManagement = new UserManagement();
                await userManagement.SendEmailAsync(user.Correo);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }
    }
}
