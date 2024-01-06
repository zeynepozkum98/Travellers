using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete
{
	public class WinterHolidayOrder : IEntity
	{
        public int WinterHolidayId { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; }

        public Order Order { get; set; }
        public WinterHoliday WinterHoliday { get; set; }
    }
}
