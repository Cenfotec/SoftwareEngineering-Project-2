using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class InfoChatBot : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("ID")]
        public int Id { get; set; }
        [DbColumn("USUARIO")]
        public string User { get; set; }
        [DbColumn("HOTEL")]
        public string Hotel { get; set; }
        [DbColumn("FECHA_INCIO")]
        public DateTime StartDate { get; set; }
        [DbColumn("FECHA_FIN")]
        public DateTime EndDate { get; set; }
        [DbColumn("HORARIO_CHECK_IN")]
        public DateTime HorarioIn { get; set; }
        [DbColumn("HORARIO_CHECK_OUT")]
        public DateTime HorarioOut { get; set; }
        [DbColumn("CHECK_IN")]
        public DateTime CheckIn { get; set; }
        [DbColumn("CHECK_OUT")]
        public DateTime CheckOut { get; set; }
        [DbColumn("TIPO_HABITACION")]
        public string RoomType { get; set; }
        [DbColumn("CANT_PERSONAS")]
        public int AmountPeople { get; set; }
        [DbColumn("PRECIO")]
        public decimal Price { get; set; }
        [DbColumn("NUM_HABITACION")]
        public int RoomNumber { get; set; }
        [DbColumn("LATITUD")]
        public string Latitude { get; set; }
        [DbColumn("LONGITUD")]
        public string Longitude { get; set; }



        public InfoChatBot() { }


        public class UsuarioChat : BaseEntity
        {
            [PrimaryKey]
            [DbColumn("USERNAME")]
            public string telegramUsername { get; set; }
            [DbColumn("FK_SUBRESERVACION")]
            public int FK_Subreservacion { get; set; }



            public UsuarioChat() { }

        }
    }
    }
