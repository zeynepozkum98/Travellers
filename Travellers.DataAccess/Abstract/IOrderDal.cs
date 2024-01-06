using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.DataAccess.EntityFramework;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.DataAccess.Abstract
{
	public interface IOrderDal:IRepository<Order>
	{
		public OrderProcessDto GetOrderProcess()
		{
			OrderProcessDto join =
				_set.Include(x => x.WinterHolidayOrders).Select(x => new OrderProcessDto()
				{
					WinterHolidayOrders = x.WinterHolidayOrders.ToList(),
					Orders = _set.ToList(),
					WinterHolidays = _context.Set<WinterHoliday>().ToList()
				}).FirstOrDefault();

			return join;
		}
	}
}
