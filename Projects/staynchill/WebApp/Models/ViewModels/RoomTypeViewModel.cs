using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.ViewModels
{
    public class RoomTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountPeople { get; set; }
        public int AmountBeds { get; set; }
        public string PetsAllowed { get; set; }
        public Double Price { get; set; }
        public string State { get; set; }
    }
}