using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travellers.Business.Abstract;
using Travellers.Business.ValidationRules.FluentValidation;
using Travellers.DataAccess.Concrete;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Traveller.WebUI.Controllers
{
    public class PlaceToVisitController : Controller
    {
        private readonly IPlaceToVisitService _placeToVisitService;
        private readonly ITourService _tourService;
       

        public PlaceToVisitController(IPlaceToVisitService placeToVisitService,ITourService tourService)
        {
			_placeToVisitService = placeToVisitService; // Dependecy Injektion 
            _tourService= tourService;
		}
        
        public async Task<IActionResult> Index() // Listeleme
        {
            List<PlaceToVisitDto> placeToVisitDtos= await _placeToVisitService.GetAllPlaceToVisitAsync();
            return View(placeToVisitDtos);
        }

        public async Task<IActionResult> Get(int id) // Tek bir veri getirme
        {
            PlaceToVisitDto placeToVisitDto= await _placeToVisitService.GetPlaceToVisitAsync(id);
            return View(placeToVisitDto);
        }


        [HttpGet]
        public async Task<IActionResult> Add() => View(); // Görünüm getirme

      
        [HttpPost]
        public async Task<IActionResult> Add(PlaceToVisitDto placeToVisitDto) // Veri ekleyip gönderme 
        {
            bool res = await _placeToVisitService.AddPlaceToVisitAsync(placeToVisitDto);
            return res ? RedirectToAction("Index") : View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            PlaceToVisitDto placeToVisitDto = await _placeToVisitService.GetPlaceToVisitAsync(id);
            return View(placeToVisitDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PlaceToVisitDto placeToVisitDto)
        {
            bool res = await _placeToVisitService.UpdatePlaceToVisitAsync(placeToVisitDto);
            return res ? RedirectToAction("Index") : View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _placeToVisitService.DeletePlaceToVisitAsync((await _placeToVisitService.GetPlaceToVisitAsync(id)));
            return res ? RedirectToAction("Index") : View();
        }




    }
}

// System.NullReferenceException: 'Object reference not set to an instance of an object.'
// Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>.Model.get returned null. hatası 