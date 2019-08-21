using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Entities.Image
{
    public class ImageHotelMapper : EntityMapperGeneric
    {
        public ImageHotelMapper() : base(dB_PR_BASE_NAME: "IMAGE_HOTEL") { }
    }
}
