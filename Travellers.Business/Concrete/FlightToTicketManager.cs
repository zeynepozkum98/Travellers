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
    public class FlightToTicketManager : IFlightToTicketService
    {
        public IFlightToTicketDal _flightToTicketDal { get; set; }
        public IMapper _mapper { get; set; }

        public FlightToTicketManager(IFlightToTicketDal flightToTicketDal,IMapper mapper)
        {
            _flightToTicketDal = flightToTicketDal;
            _mapper = mapper;
        }
    }
}
