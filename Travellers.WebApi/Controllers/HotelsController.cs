using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService) => _hotelService = hotelService;

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            HotelDto hotelDto= await  _hotelService.GetHotelAsync(id);
            return hotelDto is not null ? Ok(hotelDto) : BadRequest("Aranan otel bulunamadı");
        }

        [HttpGet]

        public async Task<IActionResult> GetList()
        {
            List<HotelDto> hotelDtos= await _hotelService.GetAllHotelAsync();
            return Ok(hotelDtos);
        }

        [HttpPost]

        public async Task<IActionResult> Add(HotelDto hotelDto) 
        {
            bool response= await _hotelService.AddHotelAsync(hotelDto);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> Update(HotelDto hotelDto) 
        {
            bool response= await _hotelService.UpdateHotelAsync(hotelDto);
            return Ok(response);

        }

        [HttpDelete]

        public async Task<IActionResult> Delete(HotelDto hotelDto) 
        {
            bool response= await  _hotelService.DeleteHotelAsync(hotelDto);
            return Ok(response);
        }
        
            
        
    }
}
