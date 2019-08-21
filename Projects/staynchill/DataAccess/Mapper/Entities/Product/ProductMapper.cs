using DataAccess.Dao;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper {
    public class ProductMapper : EntityMapperGeneric {
        public ProductMapper(): base(dB_PR_BASE_NAME: "PRODUCT") {}
    }
   
}
