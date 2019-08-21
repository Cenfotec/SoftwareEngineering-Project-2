using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Producto : BaseEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        [DbColumn("FK_SERVICIO")]
        public int Service { get; set; }
        [DbColumn("NOMBRE")]
        public string Name { get; set; }
        [DbColumn("DESCRIPCION")]
        public string Description { get; set; }
        [DbColumn("PRECIO")]
        public decimal Price { get; set; }
        [DbColumn("ESTADO")]
        public string State { get; set; }
        [DbColumn("CANT")]
        public int Cant { get; set; }
        //Imágen
        [DbColumn("Valor")]
        public string Value { get; set; }
        [DbColumn("Tipo")]
        public string Type { get; set; }

        public Producto()
        {

        }
    }
}