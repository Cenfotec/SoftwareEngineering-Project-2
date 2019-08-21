using DataAccess.Mapper;

namespace DataAccess.Crud
{
    public class SMSCrud : CrudFactory
    {
        public SMSCrud() : base(entityObjectMapper: new SMSObjectMapper(), entityMapperGeneric: new SMSMapper()) { }
    }
}