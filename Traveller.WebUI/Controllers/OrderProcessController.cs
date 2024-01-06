using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Traveller.WebUI.BasketTransaction;
using Traveller.WebUI.BasketTransaction.BasketModels;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Traveller.WebUI.Controllers
{
    public class OrderProcessController : Controller
    {
        private readonly IOrderProcessService _orderProcessService;
        private readonly IBasketTransaction _basketTransaction;
        private readonly IAuthService _authService;

        public OrderProcessController(IOrderProcessService orderProcessService,IBasketTransaction basketTransaction,IAuthService authService)
        {
            _orderProcessService = orderProcessService;
            _basketTransaction = basketTransaction;
            _authService = authService;
        }

        [Authorize]
        public IActionResult OrderProcess()
        {
            BasketDto basketDto = _basketTransaction.GetOrCreateBasket();
            AppUser appUser = _authService.GetUserByUserName(User.Identity.Name).Result;

            foreach (var item in basketDto.BasketItems)
            {
                _orderProcessService.OrderAdd(

                        new WinterHolidayOrderDto()
                        {
                            WinterHolidayId = item.WinterHolidayId,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            UserId = appUser.Id
                        });


            }

            basketDto.BasketItems.Clear();

            return View();
        }
    }
}
