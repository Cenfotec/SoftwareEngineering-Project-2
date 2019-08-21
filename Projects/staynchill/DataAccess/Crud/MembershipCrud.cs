using DataAccess.Mapper;

namespace DataAccess.Crud {
    public class MembershipCrud : CrudFactory {
        public MembershipCrud() : base(entityObjectMapper: new MembershipObjectMapper(), entityMapperGeneric: new MembershipMapper()) {}
    }
}
