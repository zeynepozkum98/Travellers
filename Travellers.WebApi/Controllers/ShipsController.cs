using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipsController : ControllerBase
    {
        private readonly IShipService _shipService;

        public ShipsController(IShipService shipService) => _shipService = shipService;

        [HttpGet("{id}")]

       

        public async Task<IActionResult> Get(int id)
        {
            ShipDto shipDto= await _shipService.GetShipAsync(id);
            return shipDto is not null ? Ok(shipDto) : NotFound("Aranılan gemi turu bulunamadı");
        }

        [HttpGet]

        public async Task<IActionResult> GetList()
        {
            List<ShipDto> shipDtos= await _shipService.GetAllShipAsync();
            return Ok(shipDtos);
        }

        [HttpPost]

        public async Task<IActionResult> Add(ShipDto shipDto)
        {
            bool response= await _shipService.AddShipAsync(shipDto);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> Update(ShipDto shipDto)
        {
            bool response= await _shipService.UpdateShipAsync(shipDto);
            return Ok(response);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(ShipDto shipDto)
        {
            bool response= await _shipService.DeleteShipAsync(shipDto);
            return Ok(response);
        }


        
            
        
    }
}
