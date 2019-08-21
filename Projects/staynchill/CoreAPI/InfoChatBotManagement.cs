using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Entities_POJO;

namespace CoreAPI
{
    public class InfoChatBotManagement
    {
        private InfoChatBotCrud infoChatBotCrud;

        public InfoChatBotManagement() => infoChatBotCrud = new InfoChatBotCrud();

        public InfoChatBot RetrieveAllById(int fkSubreserva)
        {
            return infoChatBotCrud.RetrieveAllById(fkSubreserva);
        }

        public Check GetSubReservacion(string userName) => infoChatBotCrud.GetSubReservacion(userName);

    }


}
