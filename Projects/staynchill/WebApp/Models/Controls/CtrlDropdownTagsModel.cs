using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlDropdownTagsModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string Name { get; set; }

        public CtrlDropdownTagsModel()
        {
            ViewName = "";
        }
    }
}