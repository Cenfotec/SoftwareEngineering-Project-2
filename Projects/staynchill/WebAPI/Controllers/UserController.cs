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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        ApiResponse apiResponse = new ApiResponse();

        // CREATE api/product
        [HttpPost]
        [Route("")]
        [Registered]
        public IHttpActionResult Post(User user)
        {
            apiResponse.Message = "NULO";
            try
            {
                var userManager = new UserManagement();
                var codeManager = new CodeManagement();
                if (user.Rol == "Administrador de plataforma")
                {
                    Code codeUser = codeManager.getCodeConfirmation(user.Correo);
                    if (codeUser == null)
                    {
                        apiResponse.Message = "2";
                    }
                    else if (user.Apellido == "" || user.Canton == "" || user.Cedula == "" ||
                    user.Codigo == "" || user.Contrasenna == "" || user.Correo == "" ||
                    user.Direccion == "" || user.Distrito == "" || user.Estado == "" ||
                    user.Nombre == "" || user.Provincia == "" || user.Rol == "" ||
                    user.SegApellido == "" || user.Telefono == "")
                    {
                        apiResponse.Message = "3";
                    }
                    else if (codeUser.Value == user.Codigo)
                    {
                        if (user.SegNombre == null)
                        {
                            user.SegNombre = "";
                        }
                        if (user.Imagen == null)
                        {
                            user.Imagen = "";
                        }
                        userManager.Create(user);
                        apiResponse.Message = "1";
                    }
                }
                else if (user.Rol == "Usuario final")
                {
                    Code codeUser = codeManager.getCodeConfirmation(user.Correo);
                    if (codeUser == null)
                    {
                        apiResponse.Message = "2";
                    }
                    else if (user.Apellido == "" || user.Canton == "" || user.Cedula == "" ||
                    user.Codigo == "" || user.Contrasenna == "" || user.Correo == "" ||
                    user.Direccion == "" || user.Distrito == "" || user.Estado == "" ||
                    user.Nombre == "" || user.Provincia == "" || user.Rol == "" ||
                    user.SegApellido == "" || user.Telefono == "")
                    {
                        apiResponse.Message = "3";
                    }
                    else if (codeUser.Value == user.Codigo)
                    {
                        if (user.SegNombre == null)
                        {
                            user.SegNombre = "";
                        }
                        if (user.Imagen == null)
                        {
                            user.Imagen = "";
                        }
                        userManager.CreateFinal(user);
                        apiResponse.Message = "1";
                    }
                    else
                    {
                        apiResponse.Message = "2";
                    }
                }
                else
                {
                    if (user.SegNombre == null)
                    {
                        user.SegNombre = "";
                    }

                    if (user.Rol == "Administrador de hotel")
                    {
                        userManager.CreateAdminHotel(user);
                    }
                    else if (user.Rol == "Subadministrador de hotel")
                    {
                        userManager.CreateSubAdminHotel(user);
                    }

                    apiResponse.Message = "1";
                }
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpPut]
        [Route("")]
        [Modified]
        public IHttpActionResult Put(User user)
        {
            apiResponse.Message = "NULO";
            try
            {
                if(user.Imagen == null)
                {
                    user.Imagen = "";
                }
                var userManager = new UserManagement();
                apiResponse = new ApiResponse();
                userManager.Update(user);
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        } 

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult Get()
        {
            var userManager = new UserManagement();
            apiResponse = new ApiResponse();
            List<User> users = userManager.RetrieveAll();
            apiResponse.Data = users;
            return Ok(apiResponse);
        }

        [HttpPost]
        [Route("correo")]
        public IHttpActionResult GetToUpdate(User user)
        {
            var userManager = new UserManagement();
            apiResponse = new ApiResponse();
            User usuarioObtenido = userManager.RetrieveByCorreo(user);
            apiResponse.Data = usuarioObtenido;
            return Ok(apiResponse);
        }

        // RETRIEVE api/user/id
        [Route("{Id}/{Cedula}")]
        public IHttpActionResult Get(string Id, string Cedula)
        {
            try
            {
                var userManager = new UserManagement();
                apiResponse = new ApiResponse();
                var users = userManager.RetrieveAllById(Int32.Parse(Id), Cedula);
                apiResponse.Data = users;
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("validar")]
        public IHttpActionResult Post2(User user)
        {
            try
            {
                var userManager = new UserManagement();
                apiResponse = new ApiResponse();
                var decodedCorreo = user.Correo.Replace("dotrepl-8", ".");
                var users = userManager.Validate(decodedCorreo);
                if (users == null)
                {
                    apiResponse.Data = true;
                }
                else
                {
                    apiResponse.Data = false;
                }
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        
        [Route("GetSubAdminByIdHotel/{idHotel}")]
        public IHttpActionResult Get2(int idHotel)
        {
            var userManager = new UserManagement();
            apiResponse = new ApiResponse();
            var users = userManager.RetrieveAllSubAdministradorByHotel(idHotel);
            apiResponse.Data = users;
            return Ok(apiResponse);
        }
    }
}
