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
    public class RequestCrud : CrudFactory
    {
        public RequestCrud() : base(entityObjectMapper: new RequestObjectMapper(), entityMapperGeneric: new RequestMapper()) { }

        public List<Request> RetrieveIdByHotel(Request request)
        {

            try
            {
                var rqMapper = new RequestMapper();
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        rqMapper.GetRetriveAllByIdStatement(request)
                    );

                if (lstResult.Count <= 0) return default(List<Request>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Request>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }
    }
}