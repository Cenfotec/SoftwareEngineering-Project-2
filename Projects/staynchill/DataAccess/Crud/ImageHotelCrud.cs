using DataAccess.Mapper;
using DataAccess.Mapper.Entities.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class ImageHotelCrud : CrudFactory
    {
        public ImageHotelCrud() : base(entityObjectMapper: new ImageHotelObjectMapper(), entityMapperGeneric: new ImageHotelMapper()) { }
    }
}
