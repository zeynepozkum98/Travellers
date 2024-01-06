using Microsoft.AspNetCore.Mvc;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete.Dtos;

namespace Traveller.WebUI.Controllers
{
    public class FlightToTicketController : Controller
    {
        private readonly IFlightToTicketService _flightToTicketService;

        public FlightToTicketController(IFlightToTicketService flightToTicketService) => _flightToTicketService = flightToTicketService;

        public async Task<IActionResult> Index()
        {
            List<FlightToTicketDto> flightToTicketDtos= await _flightToTicketService.GetAllFlightToTicketAsync();
            return View(flightToTicketDtos);
        }

      
        public async Task<IActionResult> Get(int id)
        {
            FlightToTicketDto flightToTicketDto= await _flightToTicketService.GetFlightToTicketAsync(id);
            return View(flightToTicketDto);
        }

        [HttpGet]
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(FlightToTicketDto flightToTicketDto)
        {
            bool isTrue = await _flightToTicketService.AddFlightToTicketAsync(flightToTicketDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            FlightToTicketDto flightToTicketDto = await _flightToTicketService.GetFlightToTicketAsync(id);
            return View(flightToTicketDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FlightToTicketDto flightToTicketDto)
        {
            bool isTrue= await _flightToTicketService.UpdateFlighToTicketAsync(flightToTicketDto);
            return isTrue ? RedirectToAction("Index") : View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool isTrue = await _flightToTicketService.DeleteFlightToTicketAsync((await _flightToTicketService.GetFlightToTicketAsync(id)));
            return isTrue ? RedirectToAction("Index") : View();
        }



      
        
            
        
    }
}
