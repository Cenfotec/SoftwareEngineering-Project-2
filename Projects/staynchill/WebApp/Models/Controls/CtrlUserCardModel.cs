using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlUserCardModel : CtrlBaseModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public CtrlUserCardModel()
        {
            ViewName = "";
        }
    }
}