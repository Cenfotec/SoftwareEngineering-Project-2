using DataAccess.Mapper;

namespace DataAccess.Crud
{
    public class AdvertisementCrud : CrudFactory
    {
        public AdvertisementCrud() : base(entityObjectMapper: new AdvertisementObjectMapper(), entityMapperGeneric: new AdvertisementMapper()) { }
    }
}