using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/hotelstats")]
    public class HotelStatsController : ApiController
    {
        ApiResponse api = new ApiResponse();

        [HttpGet]
        [Route("gettotalreservationsbymonth/{fkHotel}")]
        public IHttpActionResult Get(int fkHotel)
        {
            try
            {
                var hotelManager = new HotelStatsManagement();
                api = new ApiResponse();
                List<HotelTotalReservations> hotelStats = hotelManager.GetRetrieveHotelTotalReservations(fkHotel);
                api.Data = hotelStats;
                return Ok(api);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("getretrievehotelincomebymonth/{fkHotel}")]
        public IHttpActionResult Get2(int fkHotel)
        {
            try
            {
                var hotelManager = new HotelStatsManagement();
                api = new ApiResponse();
                List<HotelTotalReservationsByMonth> hotelStats = hotelManager.GetRetrieveHotelTotalIncomeByMonth(fkHotel);
                api.Data = hotelStats;
                return Ok(api);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("gethotelyotalincome/{fkHotel}")]
        public IHttpActionResult Get3(int fkHotel)
        {
            try
            {
                var hotelManager = new HotelStatsManagement();
                api = new ApiResponse();
                List<HotelTotalIncomeByMonth> hotelStats = hotelManager.GetHotelTotalIncome(fkHotel);
                api.Data = hotelStats;
                return Ok(api);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("gethotelanualaverageincome/{fkHotel}")]
        public IHttpActionResult Get4(int fkHotel)
        {
            try
            {
                var hotelManager = new HotelStatsManagement();
                api = new ApiResponse();
                List<HotelAnualAverageIncome> hotelStats = hotelManager.GetHotelAnualAverageIncome(fkHotel);
                api.Data = hotelStats;
                return Ok(api);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("gethotelanualtotalincome/{fkHotel}")]
        public IHttpActionResult Get5(int fkHotel)
        {
            try
            {
                var hotelManager = new HotelStatsManagement();
                api = new ApiResponse();
                List<HotelAnualTotalIncome> hotelStats = hotelManager.GetRetrieveHotelAnualTotalIncome(fkHotel);
                api.Data = hotelStats;
                return Ok(api);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}