using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Business.Abstract;
using Travellers.DataAccess.Abstract;

namespace Travellers.Business.Concrete
{
	public class OrderProcessManager : IOrderProcessService
	{
		public IOrderDal _orderDal { get; set; }
		public IWinterHolidayDal _winterHolidayDal { get; set; }
		public IWinterHolidayOrderDal _winterHolidayOrderDal { get; set; }

        public OrderProcessManager(IOrderDal orderDal,IWinterHolidayDal winterHolidayDal,IWinterHolidayOrderDal winterHolidayOrderDal)
        {
            _orderDal = orderDal;
			_winterHolidayDal = winterHolidayDal;
			_winterHolidayOrderDal = winterHolidayOrderDal;
        }
    }
}
