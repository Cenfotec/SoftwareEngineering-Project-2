using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.ViewModels
{
    public class UserListViewModel
    {
        public string Message { get; set; }
        public List<UserViewModel> Data { get; set; }
    }
}