using DataAccess.Mapper;

namespace DataAccess.Crud
{
    public class ApplicationMessageCrud : CrudFactory
    {
        public ApplicationMessageCrud() : base(entityObjectMapper: new ApplicationMessageObjectMapper(), entityMapperGeneric: new ApplicationMessageMapper()) { }
    }
}