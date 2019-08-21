﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlInputIconModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }
        public string AriaLabel { get; set; }
        public string Prepend { get; set; }

        public CtrlInputIconModel()
        {
            ViewName = "";
        }
    }
}