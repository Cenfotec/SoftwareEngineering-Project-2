using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class User : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("ID")]
        public int Id { get; set; }
        [DbColumn("CEDULA")]
        public string Cedula { get; set; }
        [DbColumn("NOMBRE")]
        public string Nombre { get; set; }
        [DbColumn("SEG_NOMBRE")]
        public string SegNombre { get; set; }
        [DbColumn("APELLIDO")]
        public string Apellido { get; set; }
        [DbColumn("SEG_APELLIDO")]
        public string SegApellido { get; set; }
        [DbColumn("CORREO")]
        public string Correo { get; set; }
        [DbColumn("TELEFONO")]
        public string Telefono { get; set; }
        [DbColumn("PROVINCIA")]
        public string Provincia { get; set; }
        [DbColumn("CANTON")]
        public string Canton { get; set; }
        [DbColumn("DISTRITO")]
        public string Distrito { get; set; }
        [DbColumn("DIRECCION")]
        public string Direccion { get; set; }
        [DbColumn("CONTRASENNA")]
        public string Contrasenna { get; set; }
        [DbColumn("ESTADO")]
        public string Estado { get; set; }
        [DbColumn("ROL")]
        public string Rol { get; set; }
        [DbColumn("FK_IMAGENES")]
        public string Imagen { get; set; }
        [DbColumn("CODIGO")]
        public string Codigo { get; set; }


        public User()
        {

        }

        public User(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 17)
            {
                Id = Int32.Parse(infoArray[0]);
                Cedula = infoArray[1];
                Nombre = infoArray[2];
                SegNombre = infoArray[3];
                Apellido = infoArray[4];
                SegApellido = infoArray[5];
                Correo = infoArray[6];
                Telefono = infoArray[7];
                Provincia = infoArray[8];
                Canton = infoArray[9];
                Distrito = infoArray[10];
                Direccion = infoArray[11];
                Contrasenna = infoArray[12];
                Estado = infoArray[13];
                Rol = infoArray[14];
                Imagen = infoArray[15];
                Codigo = infoArray[16];
            }
            else
            {
                throw new Exception("All values are require[code,name,description,ArrivalDate, taxes]");
            }

        }
    }
}
