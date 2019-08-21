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
    [RoutePrefix("api/incomestats")]
    public class IncomeStatsController : ApiController
    {
        ApiResponse api = new ApiResponse();

        [HttpGet]
        [Route("getcantventasbyday")]
        public IHttpActionResult Get()
        {
            try
            {
                var incomeStatsManager = new IncomeStatsManagement();
                api = new ApiResponse();
                List<CantVentasByDayStats> incomeStates = incomeStatsManager.RetrieveCantVentasByDayStats();
                api.Data = incomeStates;
                return Ok(api);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}