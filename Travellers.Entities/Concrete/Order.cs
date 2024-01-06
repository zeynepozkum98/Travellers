using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete
{
	public class Order : IEntity
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<WinterHolidayOrder> WinterHolidayOrders { get; set; }

    }
}
