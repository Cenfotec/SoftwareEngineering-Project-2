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
    [RoutePrefix("api/commission")]
    public class CommissionController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        // CREATE api/rol
        [Registered]
        public IHttpActionResult Post(Commission commission)
        {
            try
            {
                var commissionManager = new CommissionManagement();
                commissionManager.Create(commission);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("email")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Post2Async(EmailMembership email)
        {
            try
            {
                var commissionManager = new CommissionManagement();
                await commissionManager.Email(email);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("IsAdminHotelRegistered")]
        public IHttpActionResult Post3(Commission commission)
        {
            try
            {
                var commissionManager = new CommissionManagement();
                var tmpCommission = commissionManager.IsAdminHotelRegistered(commission.Id);
                apiResponse = new ApiResponse();
                apiResponse.Data = tmpCommission;
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("administrador")]
        public IHttpActionResult GetCommission(Commission cedulaJuridicaDeHotel)
        {
            var commissionManager = new CommissionManagement();
            apiResponse = new ApiResponse();
            var commission = commissionManager.getCommission(cedulaJuridicaDeHotel);
            apiResponse.Data = commission;
            return Ok(apiResponse);
        }

        [HttpPut]
        [Modified]
        [Route("administrador")]
        public IHttpActionResult Put(Commission commission)
        {
            var commissionManager = new CommissionManagement();
            apiResponse = new ApiResponse();
            commissionManager.Update(commission);
            apiResponse.Data = commission;
            return Ok(apiResponse);
        }
    }
}
