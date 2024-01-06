using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete.Dtos
{
    public class HotelDto:IDto
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int CategoryId { get; set; }
        public string HotelName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string NumberOfRooms { get; set; }
        public string Price { get; set; }
        
    }
}
