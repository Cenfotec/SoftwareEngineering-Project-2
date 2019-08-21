using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlTextAreaAutosizeModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string LabelClass { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }
        public string TextAreaClass { get; set; }

        public CtrlTextAreaAutosizeModel()
        {
            ViewName = "";
        }
    }
}