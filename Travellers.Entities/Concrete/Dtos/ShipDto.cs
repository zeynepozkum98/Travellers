using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete.Dtos
{
    public class ShipDto:IDto
    {

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TourId { get; set; }
        public string ShipCompany { get; set; }
        public string ShipName { get; set; }
        public string Region { get; set; }
        public string TourDuration { get; set; }
        public string Image { get; set; }
        public DateTime Period { get; set; }
        public string Price { get; set; }
    }
}
