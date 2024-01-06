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
    public class TourManager : ITourService
    {
        public ITourDal _tourDal { get; set; }
        public IMapper _mapper { get; set; }

        public TourManager(ITourDal tourDal,IMapper mapper)
        {
            _tourDal = tourDal;
            _mapper = mapper;
        }
    }
}
