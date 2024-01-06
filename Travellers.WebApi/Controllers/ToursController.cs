using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ITourService _tourService;
        public ToursController(ITourService tourService) => _tourService = tourService;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TourDto tourDto = await _tourService.GetTourAsync(id);
            return tourDto is not null ? Ok(tourDto) : BadRequest("Tur bulunamadı.");
        }


        [HttpGet]

        public async Task<IActionResult> GetList()
        {
            List<TourDto> tourDtos = await _tourService.GetAllTourAsync();
            return Ok(tourDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TourDto tourDto)
        {
            bool response = await _tourService.AddTourAsync(tourDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TourDto tourDto)
        {
            bool response = await _tourService.UpdateTourAsync(tourDto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(TourDto tourDto)
        {
            bool response = await _tourService.DeleteTourAsync(tourDto);
            return Ok(response);
        }
    }
}
