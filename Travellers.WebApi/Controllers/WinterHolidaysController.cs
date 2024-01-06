using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WinterHolidaysController : ControllerBase
	{
		private readonly IWinterHolidayService _winterHolidayService;

        public WinterHolidaysController(IWinterHolidayService winterHolidayService) => _winterHolidayService = winterHolidayService;

		[HttpGet("{id}")]

		public async Task<IActionResult> Get(int id)
		{
			WinterHolidayDto winterHolidayDto= await _winterHolidayService.GetWinterHolidayAsync(id);
			return winterHolidayDto is not null ? Ok(winterHolidayDto) : BadRequest("Otel bulunamadı");
		}

		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			List<WinterHolidayDto> winterHolidayDtos = await _winterHolidayService.GetAllWinterHolidayAsync();
			return Ok(winterHolidayDtos);
		}

		[HttpPost]
		public async Task<IActionResult> Add(WinterHolidayDto winterHolidayDto)
		{
			bool response = await _winterHolidayService.AddWinterHolidayAsync(winterHolidayDto);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> Update(WinterHolidayDto winterHolidayDto)
		{
			bool response = await _winterHolidayService.UpdateWinterHolidayAsync(winterHolidayDto);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(WinterHolidayDto winterHolidayDto)
		{
			bool response = await _winterHolidayService.DeleteWinterHolidayAsync(winterHolidayDto);
			return Ok(response);
		}
        
            
        
    }
}
