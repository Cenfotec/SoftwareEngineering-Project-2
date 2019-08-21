using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class RoomTypeManagement
    {
        private RoomTypeCrud crudTipoHabitacion;

        public RoomTypeManagement() => crudTipoHabitacion = new RoomTypeCrud();

        public void Create(RoomType tipo) => crudTipoHabitacion.Create(tipo);

        public List<RoomType> RetrieveAllById(int id) => crudTipoHabitacion.RetrieveAllById(id);

        public List<RoomType> RetrieveAll() => crudTipoHabitacion.RetrieveAll<RoomType>();

        public RoomType RetrieveById(RoomType tipo) => crudTipoHabitacion.Retrieve<RoomType>(tipo);

        public void Update(RoomType tipo) => crudTipoHabitacion.Update(tipo);

        public void Delete(RoomType tipo) => crudTipoHabitacion.Delete(tipo);
    }
}
