using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Hotel : BaseEntity
    {
        public int Id { get; set; }
        [DbColumn("NOMBRE")]
        public string Name { get; set; }
        [DbColumn("DESCRIPCION")]
        public string Description { get; set; }
        [DbColumn("CEDULA_JURIDICA")]
        [PrimaryKey]
        public string LegalNumber { get; set; }
        [DbColumn("NOMBRE_EMPRESA")]
        public string BusinessName { get; set; }
        [DbColumn("NOMBRE_CADENA")]
        public string BusinessChain { get; set; }
        [DbColumn("CORREO_HOTEL")]
        public string HotelEmail { get; set; }
        [DbColumn("TELEFONO")]
        public string PhoneNumber { get; set; }
        [DbColumn("NUM_ESTRELLAS")]
        public string Stars { get; set; }
        [DbColumn("ESTADO_HOTEL")] //Estado hotel
        public string State { get; set; }
        //Ubicacion
        [DbColumn("LATITUD")]
        public string Latitude { get; set; }
        [DbColumn("LONGITUD")]
        public string Longitude { get; set; }
        [DbColumn("PROVINCIA")]
        public string Province { get; set; }
        [DbColumn("CANTON")]
        public string Canton { get; set; }
        [DbColumn("DISTRITO")]
        public string District { get; set; }
        //Solicitud
        [DbColumn("FECHA")]
        public DateTime Date { get; set; }
        [DbColumn("VENTAS_DIA")]
        public decimal DailySales { get; set; }
        [DbColumn("VENTAS_MES")]
        public decimal MonthlySales { get; set; }
        [DbColumn("ESTADO_SOLICITUD")] //Estado solicitud
        public string RequestState { get; set; }
        [DbColumn("CORREO")] //Estado solicitud
        public string Email { get; set; }
        //Imágen
        [DbColumn("Valor")]
        public string Value { get; set; }
        [DbColumn("Tipo")]
        public string Type { get; set; }

        public Hotel()
        {

        }
    }

    public class CommissionHotel : BaseEntity
    {
        public int Id { get; set; }
        [DbColumn("NOMBRE")]
        public string Name { get; set; }
        [DbColumn("DESCRIPCION")]
        public string Description { get; set; }
        [DbColumn("CEDULA_JURIDICA")]
        [PrimaryKey]
        public string LegalNumber { get; set; }
        [DbColumn("NOMBRE_EMPRESA")]
        public string BusinessName { get; set; }
        [DbColumn("NOMBRE_CADENA")]
        public string BusinessChain { get; set; }
        [DbColumn("CORREO_HOTEL")]
        public string HotelEmail { get; set; }
        [DbColumn("TELEFONO")]
        public string PhoneNumber { get; set; }
        [DbColumn("NUM_ESTRELLAS")]
        public string Stars { get; set; }
        [DbColumn("ESTADO_HOTEL")] //Estado hotel
        public string State { get; set; }
        //Ubicacion
        [DbColumn("LATITUD")]
        public string Latitude { get; set; }
        [DbColumn("LONGITUD")]
        public string Longitude { get; set; }
        [DbColumn("PROVINCIA")]
        public string Province { get; set; }
        [DbColumn("CANTON")]
        public string Canton { get; set; }
        [DbColumn("DISTRITO")]
        public string District { get; set; }
        //Solicitud
        [DbColumn("FECHA")]
        public DateTime Date { get; set; }
        [DbColumn("VENTAS_DIA")]
        public decimal DailySales { get; set; }
        [DbColumn("VENTAS_MES")]
        public decimal MonthlySales { get; set; }
        [DbColumn("ESTADO_SOLICITUD")] //Estado solicitud
        public string RequestState { get; set; }
        [DbColumn("CORREO")] //Estado solicitud
        public string Email { get; set; }
        //Imágen
        [DbColumn("Valor")]
        public string Value { get; set; }
        [DbColumn("Tipo")]
        public string Type { get; set; }
        [DbColumn("PORCENTAJE")]
        public decimal Commission { get; set; }

        public CommissionHotel()
        {

        }
    }
}
