using Core;
using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Bitacoras;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/reservation")]
    public class ReservationController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        // POST: api/Reservation
        [Registered]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(Reservation reservation)
        {
            try
            {

                var reservationManager = new ReservationManagement();
                Reservation reservationFound = reservationManager.Create(reservation);
                apiResponse = new ApiResponse();
                apiResponse.Data = reservationFound;

                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
        // GET: api/Reservation
        public IHttpActionResult Get()
        {
            try
            {
                var reservationManager = new ReservationManagement();
                apiResponse = new ApiResponse();
                var reservations = reservationManager.RetrieveAll();
                apiResponse.Data = reservations;
                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
        
        // GET: api/Reservation/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var reservationManager = new VistaReservacionManagement();
                apiResponse = new ApiResponse();
                var reservations = reservationManager.RetrieveAllReservacion(id);
                apiResponse.Data = reservations;
                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        // POST: api/Reservation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Reservation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reservation/5
        public void Delete(int id)
        {
        }

        // RETRIEVE api/Reservation/id
        [Route("getbyid/{idReservation}")]
        public IHttpActionResult Get2(int idReservation)
        {
            try
            {
                var reservationManager = new ReservationManagement();
                apiResponse = new ApiResponse();
                var newReservation = new Reservation() { Id = idReservation };
                var reservation = reservationManager.RetrieveById(newReservation);
                apiResponse.Data = reservation;
                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPost]
        [Route("enviarfactura")]
        public async Task<IHttpActionResult> SendFacturaAsync(ReservationInvoice reservationInvoice)
        {
            try
            {

                var reservationManager = new ReservationManagement();
                await reservationManager.SendInvoiceAsync(reservationInvoice);
                apiResponse = new ApiResponse();

                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}
