using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Traveller.WebUI.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService) => _hotelService = hotelService;

        public async Task<IActionResult> Index()
        {
            List<HotelDto> hotelDtos = await _hotelService.GetAllHotelAsync();
            return View(hotelDtos);

        }

        public async Task<IActionResult> Get(int id)
        {
            HotelDto hotelDto= await _hotelService.GetHotelAsync(id);
            return View(hotelDto);
        }

        public async Task<IActionResult> DomesticHotel(int categoryId)
        {

			List<HotelDto> hotelDtos = await _hotelService.GetAllHotelAsync();
            var filteredHotels = hotelDtos.Where(x => x.CategoryId == 1).ToList();


			if (filteredHotels.Count == 0)
			{

				return View("TourError");
			}

		
			return View(filteredHotels);


		}

		public async Task<IActionResult> InternationalHotel(int categoryId)
		{
			List<HotelDto> hotelDtos = await _hotelService.GetAllHotelAsync();
            var filteredHotels = hotelDtos.Where(x=>x.CategoryId==2).ToList();
			

			if (filteredHotels.Count==0)
			{
				return View("TourError");

			}

          

            return View(filteredHotels);


			
		}




		[HttpGet]
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(HotelDto hotelDto)
        {
            bool isTrue = await _hotelService.AddHotelAsync(hotelDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            HotelDto hotelDto = await _hotelService.GetHotelAsync(id);
            return View(hotelDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HotelDto hotelDto)
        {
            bool isTrue = await _hotelService.UpdateHotelAsync(hotelDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool isTrue = await _hotelService.DeleteHotelAsync((await _hotelService.GetHotelAsync(id)));
            return isTrue ? RedirectToAction("Index") : View();
        }

        
                
        


    }
}
