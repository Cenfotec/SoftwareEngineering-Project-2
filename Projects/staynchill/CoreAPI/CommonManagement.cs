using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class CommonManagement
    {
        private CommonCrud commonCrud;

        public CommonManagement() => commonCrud = new CommonCrud();

        public void Create(Common common) => commonCrud.Create(common);

        public List<Common> RetrieveAll() => commonCrud.RetrieveAll<Common>();

    }
}
