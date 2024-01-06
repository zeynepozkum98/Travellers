using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.Business.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<City,CityDto>().ReverseMap();
            CreateMap<Contact,ContactDto>().ReverseMap();
            CreateMap<Order,OrderProcessDto>().ReverseMap();
            CreateMap<Tour,TourDto>().ReverseMap();
            CreateMap<PlaceToVisit,PlaceToVisitDto>().ReverseMap();
            CreateMap<Hotel,HotelDto>().ReverseMap();
            CreateMap<Ship,ShipDto>().ReverseMap();
            CreateMap<FlightToTicket,FlightToTicketDto>().ReverseMap();
            CreateMap<WinterHoliday,WinterHolidayDto>().ReverseMap();
            CreateMap<AppUser,RegisterDto>().ReverseMap();
            CreateMap<TourCity,TourCityDto>().ReverseMap();
            CreateMap<WinterHolidayOrder,WinterHolidayOrderDto>().ReverseMap();
           
        }
    }
}
