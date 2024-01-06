using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.DataAccess.Abstract;
using Travellers.Entities.Concrete.Dtos;
using Travellers.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Travellers.Business.Abstract
{
    public interface ITourService
    {
        public ITourDal _tourDal { get; set; }
        public IMapper _mapper { get; set; }

        public Tour TourDtoConvert(TourDto tourDto)
        {
            return _mapper.Map<Tour>(tourDto);
        }

        async Task<TourDto> GetTourAsync(int id)
        {
            Tour tour = await _tourDal.GetAsync(x => x.Id == id);
            return _mapper.Map<TourDto>(tour);
        }

        public Tour TourWithPlaceToVisitById(int id) => _tourDal.GetTourWithPlaceToVisitById(id);
        public List<Tour> TourWithPlaceToVisit() => _tourDal.TourWithPlaceToVisit();




        async Task<List<TourDto>> GetAllTourAsync()
        {
            List<Tour> tours = await _tourDal.GetAllAsync();
            List<TourDto> tourDtos = new List<TourDto>();
            foreach (Tour tour in tours)
            {
                TourDto tourDto = _mapper.Map<TourDto>(tour);
                tourDtos.Add(tourDto);
            }

            return tourDtos;
        }
        async Task<bool> AddTourAsync(TourDto tourDto)
        {
            Tour tour = TourDtoConvert(tourDto);
            int response = await _tourDal.AddAsync(tour);
            return response > 0;
        }

        async Task<bool> UpdateTourAsync(TourDto tourDto)
        {
            Tour tour = TourDtoConvert(tourDto);
            int response = await _tourDal.UpdateAsync(tour);
            return response > 0;
        }

        async Task<bool> DeleteTourAsync(TourDto tourDto)
        {
            Tour tour = TourDtoConvert(tourDto);
            int response = await _tourDal.DeleteAsync(tour);
            return response > 0;
        }

    
        
       

    }
}
