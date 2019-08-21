using DataAccess.Crud;
using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class HotelStatsManagement
    {
        private HotelsStatsCrud crudHotelStats;

        private HotelAnualIncomeCrud crudHotelAnual;

        public HotelStatsManagement()
        {
            crudHotelStats = new HotelsStatsCrud();
            crudHotelAnual = new HotelAnualIncomeCrud();
        }

        public List<HotelTotalReservations> GetRetrieveHotelTotalReservations(int fkHotel) => crudHotelStats.RetrieveHotelTotalReservations(fkHotel);

        public List<HotelTotalReservationsByMonth> GetRetrieveHotelTotalIncomeByMonth(int fkHotel) => crudHotelStats.RetrieveHotelTotalReservationsByMonth(fkHotel);

        public List<HotelTotalIncomeByMonth> GetHotelTotalIncome(int fkHotel) => crudHotelStats.RetrieveHotelTotalIncomeByMonth(fkHotel);

        public List<HotelAnualAverageIncome> GetHotelAnualAverageIncome(int fkHhotel) => crudHotelAnual.RetrieveHotelAnualAverageIncome(fkHhotel);

        public List<HotelAnualTotalIncome> GetRetrieveHotelAnualTotalIncome(int fkHotel) => crudHotelAnual.RetrieveHotelAnualTotalIncome(fkHotel);
    }
}
