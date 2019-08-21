using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class HotelStatsMapper : EntityMapperGeneric
    {
        public HotelStatsMapper() : base(dB_PR_BASE_NAME: "HOTEL") { }

        public SqlOperation GetHotelTotalReservations(int fkHotel)
        {
            var operation = new SqlOperation { ProcedureName = "CALC_TOTAL_RESERVACIONES_DE_HOTEL_PR" };
            operation.AddIntParam("FK_HOTEL", fkHotel);

            return operation;
        }

        public SqlOperation GetHotelTotalReservationsByMonth(int fkHotel)
        {
            var operation = new SqlOperation { ProcedureName = "CALC_VENTAS_POR_MES_DE_HOTEL_PR" };
            operation.AddIntParam("FK_HOTEL", fkHotel);

            return operation;
        }

        public SqlOperation GetHotelTotalIncomeByMonth(int fkHotel)
        {
            var operation = new SqlOperation { ProcedureName = "CALC_GANANCIAS_POR_MES_DE_HOTEL_PR" };
            operation.AddIntParam("FK_HOTEL", fkHotel);

            return operation;
        }
    }
}
