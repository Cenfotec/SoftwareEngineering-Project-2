using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class HotelsStatsCrud : CrudFactory
    {
        public HotelsStatsCrud() : base(entityObjectMapper: new HotelTotalReservationsObjectMapper(),
            entityMapperGeneric: new HotelStatsMapper())
        {
        }

        public List<HotelTotalReservations> RetrieveHotelTotalReservations(int fkHotel)
        {
            try
            {
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure(
                    (EntityMapperGeneric as HotelStatsMapper)?.GetHotelTotalReservations(fkHotel)
                );

                if (lstResult.Count <= 0) return default(List<HotelTotalReservations>);

                var obj = new HotelTotalReservationsObjectMapper().BuildObjects(lstResult);

                return obj.Cast<HotelTotalReservations>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }

        public List<HotelTotalReservationsByMonth> RetrieveHotelTotalReservationsByMonth(int fkHotel)
        {
            try
            {
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure(
                    (EntityMapperGeneric as HotelStatsMapper)?.GetHotelTotalReservationsByMonth(fkHotel)
                );

                if (lstResult.Count <= 0) return default(List<HotelTotalReservationsByMonth>);

                var obj = new HotelTotalReservationsByMonthObjectMapper().BuildObjects(lstResult);

                return obj.Cast<HotelTotalReservationsByMonth>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }


        public List<HotelTotalIncomeByMonth> RetrieveHotelTotalIncomeByMonth(int fkHotel)
        {
            try
            {
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure(
                    (EntityMapperGeneric as HotelStatsMapper)?.GetHotelTotalIncomeByMonth(fkHotel)
                );

                if (lstResult.Count <= 0) return default(List<HotelTotalIncomeByMonth>);

                var obj = new HotelTotalIncomeByMonthObjectMapper().BuildObjects(lstResult);

                return obj.Cast<HotelTotalIncomeByMonth>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }
    }
}