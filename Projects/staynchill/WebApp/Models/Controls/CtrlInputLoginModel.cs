using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlInputLoginModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string PlaceHolder { get; set; }
        public string Autocomplete { get; set; }
        public string Validation { get; set; }

        public CtrlInputLoginModel()
        {
            ViewName = "";
        }
    }
}