using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.Entities.Concrete
{
    public class City:IEntity
    {

       
        public int Id { get; set; }
        public string CityName { get; set; } // Şehir adı
        public bool IsDeleted { get; set; } // Silindi mi ( true or false)

        //Relational properties(İlişkisel Property'ler)
       

        public ICollection<TourCity> TourCities { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
        public ICollection<FlightToTicket> FlightTickets { get; set; }
    }
}
