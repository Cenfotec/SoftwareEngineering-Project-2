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
    [RoutePrefix("api/check")] 
    public class CheckController : ApiController
    {

        ApiResponse apiResponse = new ApiResponse();

        [HttpPost]
        [Route("fechaOut")]
        public IHttpActionResult PostGetDate(Check fkSubReservacion)
        {
            try
            {
                var checkManager = new CheckManagement();
                apiResponse = new ApiResponse();
                var res = checkManager.getDateOut(Int32.Parse(fkSubReservacion.FkSubReservacion));
                apiResponse.Data = res;
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("changeOut")]
        public IHttpActionResult PostChangeOut(Check fkSubReservacion)
        {
            try
            {
                var checkManager = new CheckManagement();
                apiResponse = new ApiResponse();
                checkManager.changeOut(Int32.Parse(fkSubReservacion.FkSubReservacion));
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("deleteCar")]
        public IHttpActionResult DeleteCar(Check fkCarrito)
        {
            try
            {
                var checkManager = new CheckManagement();
                apiResponse = new ApiResponse();
                checkManager.deleteCar(Int32.Parse(fkCarrito.FkSubReservacion));
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("permisos")]
        public IHttpActionResult Get()
        {
            try
            {
                var rolManager = new RolManagement();
                apiResponse = new ApiResponse();
                List<Rol> roles = rolManager.RetrieveAllPermisos();
                apiResponse.Data = roles;
                apiResponse.Message = "true";
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("roles")]
        public IHttpActionResult PostRoles(Rol rol)
        {
            try
            {
                var rolManager = new RolManagement();
                apiResponse = new ApiResponse();
                var res = rolManager.RetrieveAllByIdHotel(rol.Hotel);
                apiResponse.Data = res;
                apiResponse.Message = "true";
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("get")]
        public IHttpActionResult Post2(Rol rol)
        {
            try
            {
                var rolManager = new RolManagement();
                Rol res = rolManager.Validate(rol);
                var apiResponse = new ApiResponse();
                if (res == null)
                {
                    apiResponse.Data = true;
                }
                else{
                    apiResponse.Data = false;
                }
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("asignar")]
        public IHttpActionResult Post3(Rol rol)
        {
            try
            {
                var rolManager = new RolManagement();
                rolManager.Associate(rol);
                var apiResponse = new ApiResponse();
                apiResponse.Message = "true";
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("getPermisos")]
        public IHttpActionResult Post4(User user)
        {
            try
            {
                var rolManager = new RolManagement();
                List<Rol> roles = rolManager.RetrieveAllPermisosByUsuario(user);
                var apiResponse = new ApiResponse();
                apiResponse.Message = "true";
                apiResponse.Data = roles;
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("rolesbyuser")]
        public IHttpActionResult Post5(Rol rol)
        {
            try
            {
                var rolManager = new RolManagement();
                apiResponse = new ApiResponse();
                var res = rolManager.RetrieveAllByUser(rol);
                apiResponse.Data = res;
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        [Route("")]
        [Deleted]
        public IHttpActionResult Delete(Rol rol)
        {
            try
            {
                var rolManagement = new RolManagement();
                rolManagement.Delete(rol);
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