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
using PayPalCheckoutSdk.Orders;
using WebAPI.PayPal;

namespace WebAPI.Controllers
{
    public class PaymentTransactionController : ApiController
    {
        private ApiResponse apiResponse = new ApiResponse();

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
	            var paymentTransactionManagement = new PaymentTransactionManagement();
	            apiResponse = new ApiResponse();
	            var paymentTransaction = paymentTransactionManagement.RetrieveAll();
	            apiResponse.Data = paymentTransaction;
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
	            var paymentTransactionManagement = new PaymentTransactionManagement();
                var paymentTransaction = new PaymentTransaction() { Id = id };
                paymentTransaction = paymentTransactionManagement.RetrieveById(paymentTransaction);
                apiResponse = new ApiResponse
                {
                    Data = paymentTransaction
                };
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Registered]
        public IHttpActionResult Post(PaymentTransaction paymentTransaction)
        {
            try
            {
	            var paymentTransactionManagement = new PaymentTransactionManagement();
                paymentTransaction.TransactionDate = DateTime.Now;
                paymentTransactionManagement.Create(paymentTransaction);
                apiResponse = new ApiResponse();
                apiResponse.Message = "Pago realizado con exito.";
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        //paymentTransactionv2
        [HttpPost]
        [Registered]
        [Route("api/paymentTransactionv2")]
        public async System.Threading.Tasks.Task<IHttpActionResult> PaymentTransactionv2Async(PaymentTransactionV2 paymentTransactionV2)
        {
            try
            {
                var paymentTransactionManagement = new PaymentTransactionManagement();
                var paymentTransaction = paymentTransactionV2.getV1();
                var response = PayPalAPI.SendPaymentToHotel(paymentTransactionV2.PaypalEmail, (paymentTransactionV2.TotalAmount - paymentTransactionV2.CommissionTotal).ToString());

                paymentTransactionManagement.Create(paymentTransaction);
                apiResponse = new ApiResponse();
                apiResponse.Message = "Pago realizado con exito.";
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        // PUT api/<controller>/5
        [Modified]
        public IHttpActionResult Put(PaymentTransaction paymentTransaction)
        {
            try
            {
	            var paymentTransactionManagement = new PaymentTransactionManagement();
                paymentTransactionManagement.Update(paymentTransaction);
                apiResponse = new ApiResponse();
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<controller>/5
        [Deleted]
        public IHttpActionResult Delete(int id)
        {
            try
            {
	            var paymentTransactionManagement = new PaymentTransactionManagement();
                var paymentTransaction = new PaymentTransaction() { Id = id };
                paymentTransactionManagement.Delete(paymentTransaction);
                apiResponse = new ApiResponse
                {
                    Message = "Eliminado exitosamente"
                };
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}