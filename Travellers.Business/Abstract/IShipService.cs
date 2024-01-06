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
    public interface IShipService
    {
        public IShipDal _shipDal { get; set; }
        public IMapper _mapper { get; set; }

        public Ship ShipDtoConvert(ShipDto shipDto)
        {
            return _mapper.Map<Ship>(shipDto);
        }

        async Task<ShipDto> GetShipAsync(int id)
        {
            Ship ship = await _shipDal.GetAsync(x => x.Id == id);
            return _mapper.Map<ShipDto>(ship);
        }

        async Task<List<ShipDto>> GetAllShipAsync()
        {
            List<Ship> ships= await _shipDal.GetAllAsync();
            List<ShipDto> shipDtos= new List<ShipDto>();

            foreach (Ship ship in ships)
            {
                ShipDto shipDto = _mapper.Map<ShipDto>(ship);
                shipDtos.Add(shipDto);
            }

            return shipDtos;
        }

        async Task<bool> AddShipAsync(ShipDto shipDto)
        {
            Ship ship= ShipDtoConvert(shipDto);
            int response= await _shipDal.AddAsync(ship);
            return response > 0;
        }

        async Task<bool> UpdateShipAsync(ShipDto shipDto)
        {
            Ship ship= ShipDtoConvert(shipDto);
            int response= await _shipDal.UpdateAsync(ship);
            return response > 0;
        }

        async Task<bool> DeleteShipAsync(ShipDto shipDto)
        {
            Ship ship= ShipDtoConvert(shipDto);
            int response= await _shipDal.DeleteAsync(ship);
            return response > 0;
        }
    }
}
