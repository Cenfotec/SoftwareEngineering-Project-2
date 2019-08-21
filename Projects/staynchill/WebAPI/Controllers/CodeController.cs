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
using WebAPI.Bitacoras;

namespace API.Controllers
{
    [RoutePrefix("api/code")]
    public class CodeController : ApiController
    {

        ApiResponse apiResponse = new ApiResponse();

        // CREATE api/code
        [HttpPost]
        [Route("")]
        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync(Code miCode)
        {
            try
            { 
                var codeManager = new CodeManagement();
                await codeManager.SendEmailAsync(miCode.Correo, miCode.Nombre);
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
