using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete.Dtos
{
    public class TourCityDto:IDto
    {
        public int TourId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
       
    }
}
