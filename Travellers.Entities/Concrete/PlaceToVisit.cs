using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Travellers.Entities.Concrete
{
    public class PlaceToVisit:IEntity
    {
        public PlaceToVisit()
        {
            DateOfUpdate = DateTime.Now;
        }

      
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TourId { get; set; }
        public string PlaceToVisitName { get; set; } // Ziyaret edileck yerin adı
        public string Price { get; set; } // Fiyat
        public string Description { get; set; } // Açıklama
        private DateTime DateOfUpdate { get; set; } // Güncelleme tarihi
        public bool IsDeleted { get; set; } // Silindi mi ? (true or false )
        public string TypeOfTransportation { get; set; } // Ulaşım Tipi
        public string TourDuration { get; set; } // Tur Süresi
        public string StartingPoint { get; set; } // Hareket Noktası
        public string Period { get; set; } // Dönem
        public string Image { get; set; } // Resim


        // Relational properties (İlişkisel Property'ler)
      
        public virtual Category Category { get; set; } // Ziyaret edilecek yerler yalnızca bir kategoriye aittir.
        public Tour Tour { get; set; }

      

    }
}
