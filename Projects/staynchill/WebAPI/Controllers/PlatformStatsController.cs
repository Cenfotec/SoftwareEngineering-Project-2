using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebAPI.Models;

namespace WebAPI.Controllers 
{
    [RoutePrefix("api/platformstats")]
    public class PlatformStatsController : ApiController
    {
        ApiResponse api = new ApiResponse();
        
        //calcular promedio de ganancias de comisiones (plataforma)
        [HttpGet]
        [Route("getplatformcommission")]
        public IHttpActionResult Get()
        {
            try
            {
                var platStatsManager = new PlatformStatsManagement();
                api = new ApiResponse();
                PlatformStats platStats = platStatsManager.RetAllPromGanaciasComision();
                api.Data = platStats;
                return Ok(api);
            }catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        //calcular promedio de ganancias de membresia (plataforma)
        [HttpGet]
        [Route("getplatformmembership")]
        public IHttpActionResult Get2()
        {
            try
            {
                var platStatsManager = new PlatformStatsManagement();
                api = new ApiResponse();
                PlatformStats platStats = platStatsManager.RetAllPromGanaciasMembresia();
                api.Data = platStats;
                return Ok(api);
            }catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        //Caclular total de ganancias por comisiones (plataforma)
        [HttpGet]
        [Route("gettotalplatformcommission")]
        public IHttpActionResult Get3()
        {
            try
            {
                var platStatsManager = new PlatformStatsManagement();
                api = new ApiResponse();
                PlatformStats platStats = platStatsManager.RetAllGanaciasComision();
                api.Data = platStats;
                return Ok(api);
            }catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        //Caclular total de ganancias por membresia (plataforma)
        [HttpGet]
        [Route("gettotalganaplatformmembeship")]
        public IHttpActionResult Get4()
        {
            try
            {
                var platStatsManager = new PlatformStatsManagement();
                api = new ApiResponse();
                PlatformStats platStats = platStatsManager.RetAllGanaciasMembresia();
                api.Data = platStats;
                return Ok(api);
            }catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        //calcular total ganancias (plataforma)
        [HttpGet]
        [Route("gettotalplatform")]
        public IHttpActionResult Get5()
        {
            try
            {
                var platStatsManager = new PlatformStatsManagement();
                api = new ApiResponse();
                PlatformStats platStats = platStatsManager.RetAllGanaciasPlataforma();
                api.Data = platStats;
                return Ok(api);
            }catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        //caclular cantidad de hoteles (plataforma)
        [HttpGet]
        [Route("gethotels")]
        public IHttpActionResult Get6()
        {
            try
            {
                var platStatsManager = new PlatformStatsManagement();
                api = new ApiResponse();
                PlatformStats platStats = platStatsManager.RetAllHoteles();
                api.Data = platStats;
                return Ok(api);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        //calculat total de membresias (plataforma)
        [HttpGet]
        [Route("gettotalplatformemberships")]
        public IHttpActionResult Get7()
        {
            try
            {
                var platStatsManager = new PlatformStatsManagement();
                api = new ApiResponse();
                PlatformStats platStats = platStatsManager.RetAllMembresiaPlataforma();
                api.Data = platStats;
                return Ok(api);
            }catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        //calcular total de usuarios (plataforma)
        [HttpGet]
        [Route("getusers")]
        public IHttpActionResult Get8()
        {
            try
            {
                var platStatsManager = new PlatformStatsManagement();
                api = new ApiResponse();
                PlatformStats platStats = platStatsManager.RetAllUsuarios();
                api.Data = platStats;
                return Ok(api);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

    }

}