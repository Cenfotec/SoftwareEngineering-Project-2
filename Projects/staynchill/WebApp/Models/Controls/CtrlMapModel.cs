using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlMapModel : CtrlBaseModel
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public CtrlMapModel()
        {
            ViewName = "";
        }
    }
}