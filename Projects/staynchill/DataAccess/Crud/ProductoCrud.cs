using DataAccess.Dao;
using DataAccess.Mapper;
using DataAccess.Mapper.Entities.Productos;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class ProductoCrud : CrudFactory
    {
        public ProductoCrud() : base(entityObjectMapper: new ProductoObjectMapper(), entityMapperGeneric: new ProductoMapper()) { }

        ProductoMapper productoMapper = new ProductoMapper();

        public List<Producto> GetRetriveAllByHotelServicioStatement(int idHotel, int idService)
        {

            try
            {
                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        productoMapper.GetRetriveAllByHotelServicioStatement(idHotel, idService)
                    );

                if (lstResult.Count <= 0) return default(List<Producto>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Producto>().ToList();
            }
            catch (Exception e)
            {
                ManageException(e);
            }
            return null;
        }
    }
}
