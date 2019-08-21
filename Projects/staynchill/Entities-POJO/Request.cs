using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entities_POJO
{
    public class Request : BaseEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        [DbColumn("FK_HOTEL")]
        public int Hotel { get; set; }
        [DbColumn("NOMBRE_HOTEL")]
        public string HotelName { get; set; }
        [DbColumn("FECHA")]
        public DateTime Date { get; set; }
        [DbColumn("VENTAS_DIA")]
        public decimal DailySales { get; set; }
        [DbColumn("VENTAS_MES")]
        public decimal MonthlySales { get; set; }
        [DbColumn("ESTADO")]
        public string State { get; set; }
        [DbColumn("CORREO")]
        public string Email { get; set; }

        public Request()
        {

        }

        public Request(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 4)
            {
                var dailySales = 0;
                if (Int32.TryParse(infoArray[0], out dailySales))
                    DailySales = dailySales;
                else
                    throw new Exception("Las ventas de día deben ser un número");
                var monthlySales = 0;
                if (Int32.TryParse(infoArray[1], out monthlySales))
                    DailySales = dailySales;
                else
                    throw new Exception("Las ventas de mes deben ser un número");
            } else
            {
                throw new Exception("Todos los valores son requeridos [Ventas del día y ventas del mes]");
            }
        }
    }
}
