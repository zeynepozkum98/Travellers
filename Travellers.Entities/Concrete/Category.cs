using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete
{
    public class Category:IEntity // kültür turu,yurt dışı turu
    {
        
        public int Id { get; set; }
        public string CategoryName { get; set; } // Kategori Adı
        public bool IsDeleted { get; set; } // Silindi mi ( true or false)

        // Relational properties(İlişkisel Property'ler)
        public ICollection<Tour> Tours { get; set; } // Bir kategoride birden fazla tur vardır (Bire-çok İlişki)
        public ICollection<PlaceToVisit> PlaceToVisits { get; set; }
        // Bir kategoriye ait birden fazla ziyaret edilecek yerler vardır.
        // (Bire-çok İlişki)

        public ICollection<Hotel> Hotels { get; set; }
        public ICollection<Ship> Ships { get; set; }
        public ICollection<FlightToTicket> FlighTickets { get; set; }
        public ICollection<WinterHoliday> WinterHolidays { get; set; }
    }
}
