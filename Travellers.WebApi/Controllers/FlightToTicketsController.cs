using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightToTicketsController : ControllerBase
    {
        private readonly IFlightToTicketService _flightToTicketService;

        public FlightToTicketsController(IFlightToTicketService flightToTicketService) => _flightToTicketService = flightToTicketService;

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            FlightToTicketDto flightToTicketDto= await  _flightToTicketService.GetFlightToTicketAsync(id);
            return flightToTicketDto is not null ? Ok(flightToTicketDto) : BadRequest("Uçak Bileti Bulunamadı");
        }

        [HttpGet]

        public async Task<IActionResult> GetList()
        {
            List<FlightToTicketDto> flightToTicketDtos = await _flightToTicketService.GetAllFlightToTicketAsync();
            return Ok(flightToTicketDtos);
        }

        [HttpPost]

        public async Task<IActionResult> Add(FlightToTicketDto flightToTicketDto)
        {
            bool response = await _flightToTicketService.AddFlightToTicketAsync(flightToTicketDto);
            return Ok(response);

        }

        [HttpPut]

        public async Task<IActionResult> Update(FlightToTicketDto flightToTicketDto)
        {
            bool response= await _flightToTicketService.UpdateFlighToTicketAsync(flightToTicketDto);
            return Ok(response);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(FlightToTicketDto flightToTicketDto)
        {
            bool response = await _flightToTicketService.DeleteFlightToTicketAsync(flightToTicketDto);
            return Ok(response);
        }
        
            
        

    }
}
