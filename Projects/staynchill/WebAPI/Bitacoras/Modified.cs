using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using WebAPI.Models;

namespace WebAPI.Bitacoras
{
    public class Modified : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            string accion = "Modificado";
            string tipo = filterContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string hora = DateTime.Now.ToString("dd/MM/yyyy H:mm");
            CreateRegisty(accion, tipo, hora);
        }

        public void CreateRegisty(string paccion, string ptipo, string phora)
        {
            var commonManager = new CommonManagement();
            Common common = new Common(){ Action = paccion, Type = ptipo, Date = phora };
            commonManager.Create(common);
        }

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}