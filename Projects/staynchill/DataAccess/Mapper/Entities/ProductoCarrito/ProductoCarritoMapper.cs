using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ProductoCarritoMapper : EntityMapperGeneric
    {
        public ProductoCarritoMapper() : base(dB_PR_BASE_NAME: "PRODUCTO_CARRITO") { }

        public SqlOperation GetRetriveAllByIdStatement(int carrito)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_ALL_PRODUCTO_CARRITOBYID_PR" };
            operation.AddIntParam("FK_CARRITO", carrito);
            return operation;
        }

    }
}
