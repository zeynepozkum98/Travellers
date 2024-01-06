using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.DataAccess.Abstract;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.Business.Abstract
{
	public interface IWinterHolidayService
	{
		public IWinterHolidayDal _winterHolidayDal { get; set; }
		public IMapper _mapper { get; set; }

		public WinterHoliday WinterHolidayDtoConvert(WinterHolidayDto winterHolidayDto)
		{
			return _mapper.Map<WinterHoliday>(winterHolidayDto);

		}

		async Task<WinterHolidayDto> GetWinterHolidayAsync(int id)
		{
			WinterHoliday winterHoliday = await _winterHolidayDal.GetAsync(x => x.Id == id);
			return _mapper.Map<WinterHolidayDto>(winterHoliday);
		}

		async Task<List<WinterHolidayDto>> GetAllWinterHolidayAsync()
		{
			List<WinterHoliday> winterHolidays = await _winterHolidayDal.GetAllAsync();
			List<WinterHolidayDto> winterHolidayDtos= new List<WinterHolidayDto>();

			foreach (WinterHoliday winterHoliday in winterHolidays)
			{
				WinterHolidayDto winterHolidayDto = _mapper.Map<WinterHolidayDto>(winterHoliday);
				winterHolidayDtos.Add(winterHolidayDto);
			}

			return winterHolidayDtos;
		}

		async Task<bool> AddWinterHolidayAsync(WinterHolidayDto winterHolidayDto)
		{
			WinterHoliday winterHoliday = WinterHolidayDtoConvert(winterHolidayDto);
			int response = await _winterHolidayDal.AddAsync(winterHoliday);
			return response > 0;
		}

		async Task<bool> UpdateWinterHolidayAsync(WinterHolidayDto winterHolidayDto)
		{
			WinterHoliday winterHoliday= WinterHolidayDtoConvert(winterHolidayDto);
			int response= await _winterHolidayDal.UpdateAsync(winterHoliday);
			return response > 0;
		}

		async Task<bool> DeleteWinterHolidayAsync(WinterHolidayDto winterHolidayDto)
		{
			WinterHoliday winterHoliday = WinterHolidayDtoConvert(winterHolidayDto);
			int response= await _winterHolidayDal.DeleteAsync(winterHoliday);
			return response > 0;
		}
	}
}
