using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.ViewModels
{
    public class PermissionListViewModel
    {      
        public string Message { get; set; }
        public List<PermissionViewModel> Data { get; set; }
    }
}