using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class UbicationCrud : CrudFactory
    {
        public UbicationCrud() : base(entityObjectMapper: new UbicationObjectMapper(), entityMapperGeneric: new UbicationMapper()) { }
    }
}
