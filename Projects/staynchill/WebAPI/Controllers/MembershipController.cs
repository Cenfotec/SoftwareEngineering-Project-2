using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core;
using Entities_POJO;
using WebAPI.Models;
using WebAPI.Bitacoras;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Membership API methods
    /// </summary>
    public class MembershipController : ApiController
    {
        private ApiResponse apiResponse = new ApiResponse();

        /// <summary>
        /// GET api/<controller>
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            try
            {
	            var membershipManager = new MembershipManagement();
	            apiResponse = new ApiResponse();
	            var membership = membershipManager.RetrieveAll();
	            apiResponse.Data = membership;
	            return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// GET api/<controller>/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            try
            {
	            var membershipManager = new MembershipManagement();
	            var membership = new Membership() { Id = id };
	            membership = membershipManager.RetrieveById(membership);
	            apiResponse = new ApiResponse
	            {
	                Data = membership
	            };
	            return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// POST api/Membership<controller>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Registered]
        public IHttpActionResult Post(Membership membership)
        {
            try
            {
	            var membershipManager = new MembershipManagement();
                membershipManager.Create(membership);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// PUT api/<controller>/5
        /// </summary>
        /// <returns></returns>
        [Modified]
        public IHttpActionResult Put(Membership membership)
        {
            try
            {
	            var membershipManager = new MembershipManagement();
                membershipManager.Update(membership);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// DELETE api/<controller>/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Deleted]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var membershipManager = new MembershipManagement();
                membershipManager.Delete(new Membership { Id = id });
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}