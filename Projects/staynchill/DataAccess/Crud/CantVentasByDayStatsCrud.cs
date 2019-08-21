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
    public class CantVentasByDayStatsCrud : CrudFactory
    {
        public CantVentasByDayStatsCrud() : base(entityObjectMapper: new CantVentasByDayStatsObjectMapper(),
            entityMapperGeneric: new CantVentasByDayStatsMapper())
        {
        }

        public List<CantVentasByDayStats> RetrieveCantVentasByDayStats() {
            try
            {
                CantVentasByDayStatsMapper mapper = new CantVentasByDayStatsMapper();
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure(mapper.GetCantVentasByDayStats());

                if (lstResult.Count <= 0) return default(List<CantVentasByDayStats>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<CantVentasByDayStats>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }

    }
}