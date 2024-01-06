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
    public interface IHotelService
    {
        public IHotelDal _hotelDal { get; set; }
        public IMapper _mapper { get; set; }

        public Hotel HotelDtoConvert(HotelDto hotelDto)
        {
            return _mapper.Map<Hotel>(hotelDto);
        }

        async Task<HotelDto> GetHotelAsync(int id)
        {
            Hotel hotel= await _hotelDal.GetAsync(x=>x.Id==id);
            return _mapper.Map<HotelDto>(hotel);
        }

        async Task<List<HotelDto>> GetAllHotelAsync()
        {
            List<Hotel> hotels= await _hotelDal.GetAllAsync();
            List<HotelDto> hotelDtos= new List<HotelDto>();

            foreach (Hotel hotel in hotels)
            {
                HotelDto hotelDto= _mapper.Map<HotelDto>(hotel);
                hotelDtos.Add(hotelDto);
            }

            return hotelDtos;
        }

        async Task<bool> AddHotelAsync(HotelDto hotelDto)
        {
            Hotel hotel= HotelDtoConvert(hotelDto);
            int response = await _hotelDal.AddAsync(hotel);
            return response > 0;
        }

        async Task<bool> UpdateHotelAsync(HotelDto hotelDto)
        {
            Hotel hotel=HotelDtoConvert(hotelDto);
            int response= await _hotelDal.UpdateAsync(hotel);
            return response > 0;
        }

        async Task<bool> DeleteHotelAsync(HotelDto hotelDto)
        {
            Hotel hotel= HotelDtoConvert(hotelDto);
            int response= await _hotelDal.DeleteAsync(hotel);
            return response > 0;
        }

    }
}
