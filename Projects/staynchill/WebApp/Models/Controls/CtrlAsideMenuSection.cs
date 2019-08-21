using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlAsideMenuSection : CtrlBaseModel
    {
        public string Label { get; set; }

        public CtrlAsideMenuSection()
        {
            ViewName = "";
        }
    }
}