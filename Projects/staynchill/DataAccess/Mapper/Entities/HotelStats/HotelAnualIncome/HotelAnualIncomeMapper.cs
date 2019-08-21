using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class HotelAnualIncomeMapper : EntityMapperGeneric
    {
        public HotelAnualIncomeMapper() : base(dB_PR_BASE_NAME: "GANANCIAS_ANUAL_DE_HOTEL") { }

        public SqlOperation GetHotelAnualAverageIncome(int fkHotel)
        {
            var operation = new SqlOperation { ProcedureName = "CALC_PROMEDIO_GANANCIAS_ANUAL_DE_HOTEL_PR" };
            operation.AddIntParam("FK_HOTEL", fkHotel);

            return operation;
        }

        public SqlOperation GetHotelAnualTotalIncome(int fkHotel)
        {
            var operation = new SqlOperation { ProcedureName = "CALC_TOTAL_GANANCIAS_ANUAL_DE_HOTEL_PR" };
            operation.AddIntParam("FK_HOTEL", fkHotel);

            return operation;
        }
    }
}
