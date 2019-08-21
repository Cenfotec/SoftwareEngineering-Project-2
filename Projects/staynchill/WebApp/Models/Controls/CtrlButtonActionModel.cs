using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlButtonActionModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string Link { get; set; }

        public CtrlButtonActionModel()
        {
            ViewName = "";
        }
    }
}