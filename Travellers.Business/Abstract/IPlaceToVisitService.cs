using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.DataAccess.Abstract;
using Travellers.Entities.Concrete.Dtos;
using Travellers.Entities.Concrete;
using Travellers.Business.ValidationRules.FluentValidation;

namespace Travellers.Business.Abstract
{
    public interface IPlaceToVisitService
    {
        public IPlaceToVisitDal _placeToVisitDal { get; set; }
        public IMapper _mapper { get; set; }

       

        public PlaceToVisit PlaceToVisitDtoConvert(PlaceToVisitDto placeToVisitDto)
        {
            return _mapper.Map<PlaceToVisit>(placeToVisitDto);
        }

        async Task<PlaceToVisitDto> GetPlaceToVisitAsync(int id)
        {
            PlaceToVisit placeToVisit = await _placeToVisitDal.GetAsync(x => x.Id == id);
            return _mapper.Map<PlaceToVisitDto>(placeToVisit);
        }
        async Task<List<PlaceToVisitDto>> GetAllPlaceToVisitAsync()
        {
            List<PlaceToVisit> placeToVisits = await _placeToVisitDal.GetAllAsync();
            List<PlaceToVisitDto> placeToVisitDtos = new List<PlaceToVisitDto>();
            foreach (PlaceToVisit placeToVisit in placeToVisits)
            {
                PlaceToVisitDto placeToVisitDto = _mapper.Map<PlaceToVisitDto>(placeToVisit);
                placeToVisitDtos.Add(placeToVisitDto);
            }

            return placeToVisitDtos;
        }
        async Task<bool> AddPlaceToVisitAsync(PlaceToVisitDto placeToVisitDto)
        {
            PlaceToVisit placeToVisit = PlaceToVisitDtoConvert(placeToVisitDto);
            int response = await _placeToVisitDal.AddAsync(placeToVisit);
            return response > 0;
        }

        async Task<bool> UpdatePlaceToVisitAsync(PlaceToVisitDto placeToVisitDto)
        {
            PlaceToVisit placeToVisit = PlaceToVisitDtoConvert(placeToVisitDto);
            int response = await _placeToVisitDal.UpdateAsync(placeToVisit);
            return response > 0;
        }

        async Task<bool> DeletePlaceToVisitAsync(PlaceToVisitDto placeToVisitDto)
        {
            PlaceToVisit placeToVisit = PlaceToVisitDtoConvert(placeToVisitDto);
            int response = await _placeToVisitDal.DeleteAsync(placeToVisit);
            return response > 0;
        }
    }
}
