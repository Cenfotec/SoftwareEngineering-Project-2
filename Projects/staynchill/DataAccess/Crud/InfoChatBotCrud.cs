using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
    public class InfoChatBotCrud : CrudFactory
    {
        public InfoChatBotCrud() : base(entityObjectMapper: new InfoChatBotObjectMapper(), entityMapperGeneric: new InfoChatBotMapper()) { }

        public Check GetSubReservacion(string userName)
        {
            try
            {
                var checkMapper = new CheckMapper();
                var objectMapper = new CheckObjectMapper();
                var instance = SqlDao.GetInstance();
                var op = checkMapper.GetSubReservacionStatement(userName);
                var lstResult = instance.ExecuteQueryProcedure(op);

                var objts = objectMapper.BuildObjects(lstResult);

                if (lstResult.Count <= 0) return null;

                return objts.Cast<Check>().ToList().FirstOrDefault();

            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }

        public InfoChatBot RetrieveAllById(int fkSubreserva)
        {
            try
            {
                var infoMapper = new InfoChatBotMapper();
                var instance = SqlDao.GetInstance();
                var op = infoMapper.GetRetrieveAllByIdStatement(fkSubreserva);
                var lstResult = instance.ExecuteQueryProcedure(op);

                var objts = EntityObjectMapper.BuildObjects(lstResult);

                if (lstResult.Count <= 0) return null;

                return objts.Cast<InfoChatBot>().ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }
    }
}
