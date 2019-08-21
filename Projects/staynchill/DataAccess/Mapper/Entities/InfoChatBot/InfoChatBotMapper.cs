using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities_POJO.InfoChatBot;

namespace DataAccess.Mapper
{
    public class InfoChatBotMapper : EntityMapperGeneric
    {
        public InfoChatBotMapper() : base(dB_PR_BASE_NAME: "INFO_CHATBOT") { }

        public SqlOperation GetRetrieveAllByIdStatement(int fkSubreserva)
        {
            var operation = new SqlOperation { ProcedureName= "RET_ALL_INFO_CHATBOT_BY_USER_ID" };
            operation.AddIntParam("FK_SUBRESERVACION", fkSubreserva);
            return operation;
        }

        public SqlOperation CreateUser(UsuarioChat fkSubreserva)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_USUARIO_CHAT_PR" };
            operation.AddVarcharParam("USERNAME", fkSubreserva.telegramUsername);
            operation.AddIntParam("FK_SUBRESERVACION", fkSubreserva.FK_Subreservacion);

            return operation;
        }

    }
}
