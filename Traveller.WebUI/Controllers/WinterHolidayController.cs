using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traveller.WebUI.BasketTransaction.BasketModels;
using Traveller.WebUI.BasketTransaction;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete.Dtos;
using Travellers.Entities.Concrete;
using System.Drawing;

namespace Traveller.WebUI.Controllers
{
    public class WinterHolidayController : Controller
    {
        private readonly IWinterHolidayService _winterHolidayService;
        private readonly IBasketTransaction _basketTransaction;

        public WinterHolidayController(IWinterHolidayService winterHolidayService,IBasketTransaction basketTransaction)
        {
            _winterHolidayService = winterHolidayService;
            _basketTransaction = basketTransaction;
            
        }
        

        public async Task<IActionResult> Index()
        {
            List<WinterHolidayDto> winterHolidayDtos= await _winterHolidayService.GetAllWinterHolidayAsync();
            return View(winterHolidayDtos);
        }

        public async Task<IActionResult> Get(int id)
        {
            WinterHolidayDto winterHolidayDto= await _winterHolidayService.GetWinterHolidayAsync(id);
            return View(winterHolidayDto);

        }

        [HttpGet]
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(WinterHolidayDto winterHolidayDto)
        {
            bool isTrue = await _winterHolidayService.AddWinterHolidayAsync(winterHolidayDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            WinterHolidayDto winterHolidayDto = await _winterHolidayService.GetWinterHolidayAsync(id);
            return View(winterHolidayDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WinterHolidayDto winterHolidayDto)
        {
            bool isTrue = await _winterHolidayService.UpdateWinterHolidayAsync(winterHolidayDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool isTrue= await _winterHolidayService.DeleteWinterHolidayAsync((await _winterHolidayService.GetWinterHolidayAsync(id))); 
            return isTrue ? RedirectToAction("Index") : View();
        }

        public async Task<IActionResult> Details(int id)
        {
			WinterHolidayDto winterHolidayDto = await _winterHolidayService.GetWinterHolidayAsync(id);
			return winterHolidayDto != null ? View(winterHolidayDto) : View("TourError");
		}

        [HttpPost]
        public async Task<IActionResult> GetWinterHoliday(int id)
        {
            List<WinterHolidayDto> winterHolidayDtos = await _winterHolidayService.GetAllWinterHolidayAsync();
            var winterHolidayDto = winterHolidayDtos.Where(x => x.Price == id);

            if(winterHolidayDto!=null)
            {
                return View(winterHolidayDtos);
            }
            return View("TourError");
        }


        [Authorize(Roles ="User")]
        public async Task<IActionResult> AddBasketItem(int id)
        {
           
            
                WinterHolidayDto winterHolidayDto = await _winterHolidayService.GetWinterHolidayAsync(id);
                var _basketTransaction = HttpContext.RequestServices.GetRequiredService<IBasketTransaction>();
                if (winterHolidayDto != null)
                {
                    BasketItemDto basketItemDto = new BasketItemDto()
                    {
                        WinterHolidayId = winterHolidayDto.Id,
                        Name = winterHolidayDto.HotelName,
                        Image = winterHolidayDto.Image,
                        Price = winterHolidayDto.Price,
                        DateOfEntry=winterHolidayDto.DateOfEntry,
                        ReleaseDate=winterHolidayDto.ReleaseDate,
                        AccommodationType=winterHolidayDto.AccommodationType,
                        Quantity=1,
                        UserName = User.Identity.Name
                    };
                    _basketTransaction.SaveUpdateBasketItem(basketItemDto);
                }
                return RedirectToAction("Basket","Basket");
            
            
           
        }






    }
}
