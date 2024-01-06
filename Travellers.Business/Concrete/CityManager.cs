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
    public class CityManager : ICityService
    {
        public ICityDal _cityDal { get; set; }
        public IMapper _mapper { get; set; }

        public CityManager(ICityDal cityDal, IMapper mapper)
        {
            _cityDal = cityDal;
            _mapper = mapper;
        }
    }
}
