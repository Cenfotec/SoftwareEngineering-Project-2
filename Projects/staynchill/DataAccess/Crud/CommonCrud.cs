using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class CommonCrud : CrudFactory
    {
        public CommonCrud() : base(entityObjectMapper: new CommonObjectMapper(), entityMapperGeneric: new CommonMapper()) { }
    }
}
