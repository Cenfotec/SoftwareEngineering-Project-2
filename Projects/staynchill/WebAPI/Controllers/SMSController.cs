using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core;
using Entities_POJO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SMSController : ApiController
    {
        private ApiResponse apiResponse = new ApiResponse();

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                var smsManagement = new SMSManagement();
                apiResponse = new ApiResponse();
                var sms = smsManagement.RetrieveAll();
                apiResponse.Data = sms;
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var smsManagement = new SMSManagement();
                var sms = new SMS() { Id = id };
                apiResponse = new ApiResponse();
                apiResponse.Data = smsManagement.RetrieveById(sms);
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post(SMS sms)
        {
            try
            {
                var smsManagement = new SMSManagement();
                smsManagement.Create(sms);
                apiResponse = new ApiResponse
                {
                    Message = "Success",
                    Data = true
                };
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}