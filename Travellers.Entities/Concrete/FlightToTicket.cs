using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete
{
    public class FlightToTicket : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TourId { get; set; }
        public int CityId { get; set; }
        public string FlightCompany { get; set; } // Uçak Firması
        public string DepartureTime { get; set; } // Kalkış Saati
        public string FlightTime { get; set; } // Uçuş Süresi
        public string TransferStatus { get; set; } // Aktarma Durumu
        public string LuggageStatus { get; set; } // Bagaj Durumu
        public string Price { get; set; } // Fiyat
        public bool IsDeleted { get; set; }

        public Category Category { get; set; }
        public Tour Tour { get; set; }
        public City City { get; set; }
    }
}
