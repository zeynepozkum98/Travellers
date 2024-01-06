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
	public class WinterHolidayManager : IWinterHolidayService
	{
		public IWinterHolidayDal _winterHolidayDal { get; set; }
		public IMapper _mapper { get; set; }

        public WinterHolidayManager(IWinterHolidayDal winterHolidayDal,IMapper mapper)
        {
            _winterHolidayDal = winterHolidayDal;
            _mapper = mapper;
        }
    }
}
