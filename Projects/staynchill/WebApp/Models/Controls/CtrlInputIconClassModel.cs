using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlInputIconClassModel : CtrlBaseModel
    {
        public string IconClass { get; set; }
        public string InputClass { get; set; }
        public string InputType { get; set; }
        public string Placeholder { get; set; }
        public string Name { get; set; }
        public string Attributes { get; set; }

        public CtrlInputIconClassModel()
        {
            ViewName = "";
        }
    }
}