using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traveller.WebUI.BasketTransaction;
using Traveller.WebUI.BasketTransaction.BasketModels;

namespace Traveller.WebUI.Controllers
{
	public class BasketController : Controller
	{
		private readonly IBasketTransaction _basketTransaction;
		

        public BasketController(IBasketTransaction basketTransaction)
        {
            _basketTransaction = basketTransaction;
        }

		[HttpGet]
		[Authorize(Roles ="User")]
        public IActionResult Basket()
		{
			BasketDto basketDto = _basketTransaction.GetOrCreateBasket();
			return View(basketDto);
		}

		[HttpGet]
        public IActionResult DecreaseQuantity(int winterHolidayId)
		{
			_basketTransaction.RemoveOrDecrease(winterHolidayId);
			return RedirectToAction("Basket");
		}

		[HttpGet]
		public IActionResult IncreaseQuantity(int winterHolidayId) 
		{
			_basketTransaction.AddOrIncreaseQuantity(winterHolidayId);
			return RedirectToAction("Basket");
		}

		[HttpGet]
		public IActionResult DeleteItem(int winterHolidayId)
		{
			_basketTransaction.DeleteItem(winterHolidayId);
			return RedirectToAction("Basket");
		}

		[HttpGet]
		public IActionResult BasketClean()
		{
			_basketTransaction.DeleteBasket();
			return RedirectToAction("Basket");
		}
	}
}
