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
    public class HotelAnualIncomeCrud : CrudFactory
    {
        public HotelAnualIncomeCrud() : base(entityObjectMapper: new HotelAnualAverageIncomeObjectMapper(),
            entityMapperGeneric: new HotelAnualIncomeMapper())
        {
        }

        public List<HotelAnualAverageIncome> RetrieveHotelAnualAverageIncome(int fkHotel)
        {
            try
            {
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure(
                    (EntityMapperGeneric as HotelAnualIncomeMapper)?.GetHotelAnualAverageIncome(fkHotel)
                );

                if (lstResult.Count <= 0) return default(List<HotelAnualAverageIncome>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<HotelAnualAverageIncome>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }

        public List<HotelAnualTotalIncome> RetrieveHotelAnualTotalIncome(int fkHotel)
        {
            try
            {
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure(
                    (EntityMapperGeneric as HotelAnualIncomeMapper)?.GetHotelAnualTotalIncome(fkHotel)
                );

                if (lstResult.Count <= 0) return default(List<HotelAnualTotalIncome>);

                var obj = new HotelAnualTotalIncomeObjectMapper().BuildObjects(lstResult);

                return obj.Cast<HotelAnualTotalIncome>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }

    }
}
