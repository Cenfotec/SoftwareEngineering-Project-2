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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class QRCodeResInvModel
    {
        public QRCode qrCode { get; set; }
        public ReservationInvoice reservationInvoice { get; set; }
    }

    [RoutePrefix("api/qrcode")]
    public class QRCodeController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        public async Task<IHttpActionResult> PostAsync(QRCodeResInvModel qRCodeResInvModel)
        {

            try
            {
                string userEmail = qRCodeResInvModel.qrCode.State;
                var qrCodeManager = new QRCodeManagement();
                QRCode qrcode = qrCodeManager.Create(qRCodeResInvModel.qrCode, "PROPIO_ENA");
                string qrCodeValue = qrcode.Value;
                var userManager = new UserManagement();
                var tmpUser = new User() { Correo = userEmail };
                User user = userManager.RetrieveByCorreo(tmpUser);

                // Send Email
                await qrCodeManager.SendEmailWithFactura(user, qrCodeValue, qRCodeResInvModel.reservationInvoice);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPost]
        [Route("enviar_no_registrado")]
        public async Task<IHttpActionResult> Post2Async(QRCode qrcode)
        {
            try
            {
                // State is email
                var qrCodeManager = new QRCodeManagement();
                var user = new User() { Correo = qrcode.State };

                // Id is reservation ID
                var qrCodeFound = qrCodeManager.RetrieveByReservationId(qrcode.Id);

                // Send Email
                await qrCodeManager.SendEmail(user, qrCodeFound.Value);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPost]
        [Route("enviar_registrado")]
        public async Task<IHttpActionResult> Post3Async(Reservation reservation)
        {
            try
            {
                var qrCodeManager = new QRCodeManagement();
                var userManager = new UserManagement();
                var reservationManager = new ReservationManagement();

                // State is user email
                var user = new User() { Correo = reservation.State };
                var userFound = userManager.RetrieveByCorreo(user);
                var subReservationCreated = reservationManager.CreateSubreservation(reservation, userFound);

                // Build QR Code
                QRCode code = new QRCode() {
                    Id = userFound.Id,
                    Value = "none",
                    State = "none",
                    FK_SubReservation = subReservationCreated.FkSubreservation
                };
                QRCode qrcode = qrCodeManager.Create(code, "INVITADO_ENA");

                // Send Email
                await qrCodeManager.SendEmail(user, qrcode.Value);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpGet]
        [Route("llavesgeneradas")]
        public IHttpActionResult GetLlavesGeneradas(int idReservation)
        {
            try
            {
                var qrCodeManager = new QRCodeManagement();
                var qrcodes = qrCodeManager.RetrieveAllByReservationId(idReservation);

                apiResponse = new ApiResponse();
                apiResponse.Data = qrcodes;
                return Ok(apiResponse);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}