﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete
{
	public class WinterHoliday : IEntity
	{
		public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TourId { get; set; }
        public string HotelName { get; set; }
        public string Region { get; set; }
        public string AccommodationType { get; set; }
        public string FacilityAmenities { get; set; }
		public DateTime DateOfEntry { get; set; }
		public DateTime ReleaseDate { get; set; }
		public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }

        public bool IsDeleted { get; set; }

        public Category Category { get; set; }
        public Tour Tour { get; set; }

        public ICollection<WinterHolidayOrder> WinterHolidayOrders { get; set; }
    }
}
