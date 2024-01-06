using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete.Dtos
{
	public class WinterHolidayOrderDto:IDto
	{
        public int WinterHolidayId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
