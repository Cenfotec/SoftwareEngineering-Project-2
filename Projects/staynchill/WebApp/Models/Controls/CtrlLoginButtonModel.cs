using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlLoginButtonModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public string ClickFunction { get; set; }

        public CtrlLoginButtonModel()
        {
            ViewName = "";
        }
    }
}