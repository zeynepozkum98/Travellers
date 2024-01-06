using Microsoft.AspNetCore.Mvc;
using Traveller.WebUI.BasketTransaction.BasketModels;
using Traveller.WebUI.BasketTransaction;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Traveller.WebUI.Controllers
{
    public class ShipController : Controller
    {
        private readonly IShipService _shipService;
        private readonly ITourService _tourService;

        public ShipController(IShipService shipService, ITourService tourService)
        {
            _shipService = shipService;
            _tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            List<ShipDto> shipDtos= await _shipService.GetAllShipAsync();
            return View(shipDtos);
        }
        public async Task<IActionResult> Get(int id)
        {
            ShipDto shipDto= await _shipService.GetShipAsync(id);
            return View(shipDto);
        }

        public async Task<IActionResult> Detail(int id)
        {
          
            List<ShipDto> shipDtos = await _shipService.GetAllShipAsync();
            var ship = shipDtos.Where(x=>x.TourId==id).ToList();


            if (ship==null)
            {

                return View("TourError");
            }

            return View(ship);


           
        }

        public async Task<IActionResult> Ship(int categoryId)
        {
            List<TourDto> tourDtos = await _tourService.GetAllTourAsync();
            var filteredTours = tourDtos.Where(x => x.CategoryId == 5).ToList();


            if (filteredTours.Count == 0)
            {

                return View("CategoryNotFound");
            }

          
            return View(filteredTours);
            
        }

        [HttpGet]
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(ShipDto shipDto)
        {
            bool isTrue= await _shipService.AddShipAsync(shipDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ShipDto shipDto = await _shipService.GetShipAsync(id);
            return View(shipDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ShipDto shipDto)
        {
            bool isTrue= await _shipService.UpdateShipAsync(shipDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool isTrue = await _shipService.DeleteShipAsync((await _shipService.GetShipAsync(id)));
            return isTrue ? RedirectToAction("Index") : View();
        }

        

    }


}

