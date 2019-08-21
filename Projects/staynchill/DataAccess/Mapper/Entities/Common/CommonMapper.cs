using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper {
    public class CommonMapper : EntityMapperGeneric {
        //Preguntar si este nombre esta bien
        public CommonMapper(): base(dB_PR_BASE_NAME: "COMMON") {}
    }
}