using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete.Dtos
{
	public class OrderProcessDto:IDto
	{
        public List<Order> Orders { get; set; }
        public List<WinterHolidayOrder> WinterHolidayOrders { get; set; }
        public List<WinterHoliday> WinterHolidays { get; set; }
    }
}
