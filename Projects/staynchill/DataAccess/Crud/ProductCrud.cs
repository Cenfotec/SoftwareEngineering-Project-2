using DataAccess.Mapper;

namespace DataAccess.Crud {
    public class ProductCrud : CrudFactory {
        public ProductCrud() : base(entityObjectMapper: new ProductObjectMapper(), entityMapperGeneric: new ProductMapper()) {
        }
    }
}
