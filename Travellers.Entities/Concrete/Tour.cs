using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.Entities.Concrete
{
    public class Tour:IEntity // karadeniz turu,gap turu ve avrupa turu gibi...
    {
        public Tour() // Yapıcı(Constructor) Metot
        {
            DateOfUpdate= DateTime.Now;
            
        }

    
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string TourName { get; set; } // Tur Adı
        public string Image { get; set; } // Resim
        private DateTime DateOfUpdate { get; set; } // Güncelleme Tarihi
        public bool IsDeleted { get; set; } // Silindi mi ?

        // Relational properties (İlişkisel Property'ler)

        
        public virtual Category Category { get; set; } // Bir tur ise yalnızca bir kategoriye aittir.

        public ICollection<PlaceToVisit> PlaceToVisits { get; set; }
        public ICollection<Ship> Ships { get; set; }
        public ICollection<FlightToTicket> FlightToTickets { get; set; }
        public ICollection<WinterHoliday> WinterHolidays { get; set; }

        public ICollection<TourCity> TourCities { get; set; }
    }
}
