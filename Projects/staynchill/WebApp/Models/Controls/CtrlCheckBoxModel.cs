using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlCheckBoxModel : CtrlBaseModel
    {
        public string IdCheckBox1 { get; set; }
        public string IdCheckBox2 { get; set; }
        public string Label { get; set; }
        public string Name{ get; set; }
        public string Value { get; set; }
        public string Valueb { get; set; }
        public string Placeholder { get; set; }

        public CtrlCheckBoxModel()
        {
            ViewName = "";
        }
    }
}