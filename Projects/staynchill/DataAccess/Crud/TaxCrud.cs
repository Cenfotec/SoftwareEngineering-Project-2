using DataAccess.Mapper;

namespace DataAccess.Crud {
    class TaxCrud : CrudFactory {
        public TaxCrud() : base(entityObjectMapper: new TaxObjectMapper(), entityMapperGeneric: new TaxMapper()) { }
    }
}
