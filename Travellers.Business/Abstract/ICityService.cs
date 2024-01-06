using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.DataAccess.Abstract;
using Travellers.Entities.Concrete.Dtos;
using Travellers.Entities.Concrete;

namespace Travellers.Business.Abstract
{
    public interface ICityService
    {
        public ICityDal _cityDal { get; set; }
        public IMapper _mapper { get; set; }

        public City CityDtoConvert(CityDto cityDto)
        {
            return _mapper.Map<City>(cityDto);
        }

        async Task<CityDto> GetCityAsync(int id)
        {
            City city = await _cityDal.GetAsync(x => x.Id == id);
            return _mapper.Map<CityDto>(city);
        }
        async Task<List<CityDto>> GetAllCity()
        {
            List<City> cities = await _cityDal.GetAllAsync();
            List<CityDto> cityDtos = new List<CityDto>();
            foreach (City city in cities)
            {
                CityDto cityDto = _mapper.Map<CityDto>(city);
                cityDtos.Add(cityDto);
            }

            return cityDtos;
        }
        async Task<bool> AddCityAsync(CityDto cityDto)
        {
            City city = CityDtoConvert(cityDto);
            int response = await _cityDal.AddAsync(city);
            return response > 0;
        }

        async Task<bool> UpdateCityAsync(CityDto cityDto)
        {
            City city = CityDtoConvert(cityDto);
            int response = await _cityDal.UpdateAsync(city);
            return response > 0;
        }

        async Task<bool> DeleteCityAsync(CityDto cityDto)
        {
            City city = CityDtoConvert(cityDto);
            int response = await _cityDal.DeleteAsync(city);
            return response > 0;
        }
    }
}
