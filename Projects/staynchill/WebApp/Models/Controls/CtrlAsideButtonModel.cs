using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlAsideButtonModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }

        public CtrlAsideButtonModel()
        {
            ViewName = "";
        }
    }
}