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
    public interface IFlightToTicketService
    {
        public IFlightToTicketDal _flightToTicketDal {  get; set; }
        public IMapper _mapper { get; set; }

        public FlightToTicket FlightToTicketDtoConvert(FlightToTicketDto flightToTicketDto)
        {
            return _mapper.Map<FlightToTicket>(flightToTicketDto);
        }

        async Task<FlightToTicketDto> GetFlightToTicketAsync(int id)
        {
            FlightToTicket flightToTicket = await  _flightToTicketDal.GetAsync(x => x.Id == id);
            return _mapper.Map<FlightToTicketDto>(flightToTicket);
        }

        async Task<List<FlightToTicketDto>> GetAllFlightToTicketAsync()
        {
            List<FlightToTicket> flightToTickets= await _flightToTicketDal.GetAllAsync();
            List<FlightToTicketDto> flightToTicketDtos = new List<FlightToTicketDto>();

            foreach (FlightToTicket flightToTicket in flightToTickets)
            {
                FlightToTicketDto flightToTicketDto = _mapper.Map<FlightToTicketDto>(flightToTicket);
                flightToTicketDtos.Add(flightToTicketDto);
            }

            return flightToTicketDtos;
        }

        async Task<bool> AddFlightToTicketAsync(FlightToTicketDto flightToTicketDto)
        {
            FlightToTicket flightToTicket = FlightToTicketDtoConvert(flightToTicketDto);
            int response= await _flightToTicketDal.AddAsync(flightToTicket);
            return response > 0;
        }

        async Task<bool> UpdateFlighToTicketAsync(FlightToTicketDto flightToTicketDto)
        {
            FlightToTicket flightToTicket = FlightToTicketDtoConvert(flightToTicketDto);
            int response= await _flightToTicketDal.UpdateAsync(flightToTicket);
            return response > 0;
        }

        async Task<bool> DeleteFlightToTicketAsync(FlightToTicketDto flightToTicketDto)
        {
            FlightToTicket flightToTicket = FlightToTicketDtoConvert(flightToTicketDto);
            int response= await _flightToTicketDal.DeleteAsync(flightToTicket);
            return response > 0;
        }
    }
}
