using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlDropdownModel : CtrlBaseModel
    {
        public string Class { get; set; }
        public string SelectId { get; set; }
        public string OptionId { get; set; }
        public string ColumnDataName { get; set; }
        public string Label { get; set; }

        public CtrlDropdownModel()
        {
            ViewName = "";
        }
    }
}