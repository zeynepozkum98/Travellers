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
    public class ShipManager : IShipService
    {
        public IShipDal _shipDal { get; set; }
        public IMapper _mapper { get; set; }

        public ShipManager(IShipDal shipDal,IMapper mapper)
        {
            _shipDal = shipDal;
            _mapper = mapper;
        }
    }
}
