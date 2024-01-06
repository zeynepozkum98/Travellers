using Microsoft.AspNetCore.Mvc;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete.Dtos;

namespace Traveller.WebUI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService) => _cityService = cityService;
     
        public async Task<IActionResult> Index()
        {
            List<CityDto> cityDtos = await _cityService.GetAllCity();
            return View(cityDtos);
        }

        public async Task<IActionResult> Get(int id)
        {
            CityDto cityDto= await _cityService.GetCityAsync(id);
            return View(cityDto);
        }


        [HttpGet]
        public async Task<IActionResult> Add() => View();
        

        [HttpPost]
        public async Task<IActionResult> Add(CityDto cityDto)
        {
            bool isTrue= await _cityService.AddCityAsync(cityDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            CityDto cityDto = await _cityService.GetCityAsync(id);
            return View(cityDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CityDto cityDto)
        {
            bool isTrue= await _cityService.UpdateCityAsync(cityDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool isTrue= await _cityService.DeleteCityAsync((await _cityService.GetCityAsync(id)));
            return isTrue ? RedirectToAction("Index") : View();
        }
    }
}
