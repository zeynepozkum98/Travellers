using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Traveller.WebUI.BasketTransaction;
using Traveller.WebUI.BasketTransaction.BasketModels;
using Travellers.Business.Abstract;
using Travellers.DataAccess.Concrete;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Traveller.WebUI.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IPlaceToVisitService _placeToVisitService;
        private readonly IFlightToTicketService _flightToTicketService;
        private readonly IWinterHolidayService _winterHolidayService;
        private readonly IBasketTransaction _basketTransaction;

		public TourController(ITourService tourService,IPlaceToVisitService placeToVisitService,IFlightToTicketService flightToTicketService, IBasketTransaction basketTransaction,IWinterHolidayService winterHolidayService)
        {
			_tourService = tourService;
            _placeToVisitService = placeToVisitService;
            _flightToTicketService = flightToTicketService;
            _winterHolidayService = winterHolidayService;
            _basketTransaction = basketTransaction;
		}
        

        public async Task<IActionResult> Index()
        {
            List<TourDto> tourDtos = await _tourService.GetAllTourAsync();
            return View(tourDtos);
        }

       
        public async Task<IActionResult> CulturalTours(int categoryId)
        {
            List<TourDto> tourDtos = await _tourService.GetAllTourAsync();
            var filteredTours = tourDtos.Where(x => x.CategoryId == 3).ToList();
         

            if (filteredTours.Count == 0)
            {
              
                return View("CategoryNotFound");
            }

            // Filtrelenmiş turları DTO'larını View'e ileterek listeleyin
            return View(filteredTours);
        }

        public async Task<IActionResult> InternationalTours(int categoryId)
        {
            List<TourDto> tourDtos = await _tourService.GetAllTourAsync();
            var filteredTours = tourDtos.Where(x=>x.CategoryId==4).ToList();

            if (filteredTours.Count == 0)
            {

                return View("CategoryNotFound");
            }

            // Filtrelenmiş turları DTO'larını View'e ileterek listeleyin
            return View(filteredTours);

        }

        public async Task<IActionResult> FlightToTicket(int categoryId)
        {
            List<TourDto> tourDtos = await _tourService.GetAllTourAsync();
            var filteredTours = tourDtos.Where(x => x.CategoryId == 6).ToList();

            if (filteredTours.Count == 0)
            {

                return View("CategoryNotFound");
            }

            // Filtrelenmiş turları DTO'larını View'e ileterek listeleyin
            return View(filteredTours);

        }

        public async Task<IActionResult> WinterHoliday(int categoryId)
        {
            List<TourDto> tourDtos = await _tourService.GetAllTourAsync();
            var filteredTours= tourDtos.Where(x=>x.CategoryId==7).ToList();

            if (filteredTours.Count==0)
            {
                return View("CategoryNotFound");
            }

            return View(filteredTours);
        }

        public async Task<IActionResult> Detail(int id)
        {
            List<PlaceToVisitDto> placeToVisitDtos= await _placeToVisitService.GetAllPlaceToVisitAsync();
            var placeVisitDto= placeToVisitDtos.Where(x=>x.TourId==id).ToList();

            if (placeVisitDto==null)
            {
                return View("TourError");
            }

            return View(placeVisitDto);
        }

        public async Task<IActionResult> Details(int id)
        {
            List<PlaceToVisitDto> placeToVisitDtos = await _placeToVisitService.GetAllPlaceToVisitAsync();
            var placeVisitDto= placeToVisitDtos.Where(x=>x.TourId==id).ToList();

            if (placeVisitDto==null)
            {
                return View("TourError");
            }

            return View(placeVisitDto);
            
        }

        public async Task<IActionResult> DetailPage(int id)
        {
            List<PlaceToVisitDto> placeToVisitDtos = await _placeToVisitService.GetAllPlaceToVisitAsync();
            var placeVisitDto= placeToVisitDtos.Where(x=>x.TourId== id).ToList();

            if (placeVisitDto==null)
            {
                return View("TourError");
            }

            return View(placeVisitDto);
        }

        public async Task<IActionResult> HolidayList(int id)
        {
            List<WinterHolidayDto> winterHolidayDtos= await _winterHolidayService.GetAllWinterHolidayAsync();
            var winterHolidayDto= winterHolidayDtos.Where(x=>x.TourId == id).ToList();

            if (winterHolidayDto==null)
            {
                return View("TourError");
            }

            return View(winterHolidayDto);
        }

    
        public async Task<IActionResult> DetailList(int id)
        {
            List<FlightToTicketDto> flightToTicketDtos= await _flightToTicketService.GetAllFlightToTicketAsync();
            var flightTicketDto= flightToTicketDtos.Where(x=>x.TourId == id).ToList();

            if (flightTicketDto==null)
            {
                return View("TourError");
            }

            return View(flightTicketDto);
        }

        [Authorize]
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
                    Price = winterHolidayDto.Price,
                    Quantity = 1,
                    UserName = User.Identity.Name
                };
                _basketTransaction.SaveUpdateBasketItem(basketItemDto);
            }
            return RedirectToAction("HolidayList");
        }

        public async Task<IActionResult> Get(int id)
        {
            TourDto tourDto= await _tourService.GetTourAsync(id);
            return View(tourDto);
        }

        [HttpGet]

        public async Task<IActionResult> Add() => View("Add");

        [HttpPost]

        public async Task<IActionResult> Add(TourDto tourDto)
        {
            bool isTrue=await _tourService.AddTourAsync(tourDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            TourDto tourDto = await _tourService.GetTourAsync(id);
            return View(tourDto);
        }

        [HttpPost]

        public async Task<IActionResult> Update(TourDto tourDto)
        {
            bool isTrue= await _tourService.UpdateTourAsync(tourDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool isTrue = await _tourService.DeleteTourAsync((await _tourService.GetTourAsync(id)));
            return isTrue ? RedirectToAction("Index") : View();
        }
    }
}
