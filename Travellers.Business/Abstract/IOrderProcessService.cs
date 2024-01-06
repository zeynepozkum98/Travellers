using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.DataAccess.Abstract;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.Business.Abstract
{
	public interface IOrderProcessService
	{
        public IOrderDal _orderDal { get; set; }
        public IWinterHolidayDal _winterHolidayDal { get; set; }
        public IWinterHolidayOrderDal _winterHolidayOrderDal { get; set; }

        public OrderProcessDto GetOrderDetails()
        {
            return _orderDal.GetOrderProcess();
        }

        public async Task<bool> OrderAdd(WinterHolidayOrderDto winterHolidayOrderDto)
        {
            try
            {

                int response = _orderDal.AddAsync(new Order() { UserId = winterHolidayOrderDto.UserId, }).Result;
                int orderId = _orderDal.GetAllAsync().Result.Max(x => x.Id);
                response = _winterHolidayOrderDal.AddAsync(new WinterHolidayOrder() { Price = winterHolidayOrderDto.Price, Quantity = winterHolidayOrderDto.Quantity, WinterHolidayId = winterHolidayOrderDto.WinterHolidayId, OrderId = orderId, TotalPrice = winterHolidayOrderDto.Quantity * winterHolidayOrderDto.Price }).Result;

                WinterHoliday winterHoliday = _winterHolidayDal.GetAsync(x => x.Id == winterHolidayOrderDto.WinterHolidayId).Result;
                winterHoliday.Quantity -= winterHolidayOrderDto.Quantity;
                await _winterHolidayDal.UpdateAsync(winterHoliday);

                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
