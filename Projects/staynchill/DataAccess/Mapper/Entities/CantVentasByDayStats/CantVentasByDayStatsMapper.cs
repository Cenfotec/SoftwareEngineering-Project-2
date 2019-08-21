using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Mapper
{
    public class CantVentasByDayStatsMapper : EntityMapperGeneric
    {
        public CantVentasByDayStatsMapper() : base(dB_PR_BASE_NAME: "CANTIDAD_TRANSACCIONES_POR_DIA") { }

        public SqlOperation GetCantVentasByDayStats()
        {
            return new SqlOperation { ProcedureName = "CALC_CANTIDAD_TRANSACCIONES_POR_DIA_DEL_MES_ACTUAL_PR" };
        }
    }
}

