using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Business.Abstract;
using Travellers.DataAccess.Abstract;

namespace Travellers.Business.Concrete
{
    public class PlaceToVisitManager : IPlaceToVisitService
    {
        public IPlaceToVisitDal _placeToVisitDal { get; set; }
        public IMapper _mapper { get; set; }

        public PlaceToVisitManager(IPlaceToVisitDal placeToVisitDal, IMapper mapper)
        {
            _placeToVisitDal = placeToVisitDal;
            _mapper = mapper;
        }
    }
}
