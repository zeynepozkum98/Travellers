using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceToVisitsController : ControllerBase
    {
        private readonly IPlaceToVisitService _placeToVisitService;
        public PlaceToVisitsController(IPlaceToVisitService placeToVisitService) => _placeToVisitService = placeToVisitService;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PlaceToVisitDto placeToVisitDto = await  _placeToVisitService.GetPlaceToVisitAsync(id);
            return placeToVisitDto is not null ? Ok(placeToVisitDto) : BadRequest("Ziyaret edilecek yer bulunamadı.");
        }


        [HttpGet]

        public async Task<IActionResult> GetList()
        {
            List<PlaceToVisitDto> placeToVisitDtos = await _placeToVisitService.GetAllPlaceToVisitAsync();
            return Ok(placeToVisitDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlaceToVisitDto placeToVisitDto)
        {
            bool response = await _placeToVisitService.AddPlaceToVisitAsync(placeToVisitDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PlaceToVisitDto placeToVisitDto)
        {
            bool response = await _placeToVisitService.UpdatePlaceToVisitAsync(placeToVisitDto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(PlaceToVisitDto placeToVisitDto)
        {
            bool response = await _placeToVisitService.DeletePlaceToVisitAsync(placeToVisitDto);
            return Ok(response);
        }
    }
}
