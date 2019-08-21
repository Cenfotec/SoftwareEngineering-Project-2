using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class RequestManagement
    {
        private RequestCrud crudRequest;

        public RequestManagement() => crudRequest = new RequestCrud();

        public void Create(Request request) => crudRequest.Create(request);

        public List<Request> RetrieveAll() => crudRequest.RetrieveAll<Request>();

        public Request RetrieveById(Request request) => crudRequest.Retrieve<Request>(request);

        public void Update(Request request) => crudRequest.Update(request);

        public List<Request> RetrieveIdByHotel(Request request) => crudRequest.RetrieveIdByHotel(request);

    }
}
