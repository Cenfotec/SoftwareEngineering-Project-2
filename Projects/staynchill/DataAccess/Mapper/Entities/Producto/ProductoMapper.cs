using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Entities.Productos
{
    public class ProductoMapper : EntityMapperGeneric
    {
        public ProductoMapper() : base(dB_PR_BASE_NAME: "PRODUCTO") { }

        public SqlOperation GetRetriveAllByHotelServicioStatement(int idHotel, int idService)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_PRODUCTO_BY_HOTEL_PR" };
            operation.AddIntParam("ID_HOTEL", idHotel);
            operation.AddIntParam("ID_SERVICIO", idService);
            return operation;
        }
    }
}