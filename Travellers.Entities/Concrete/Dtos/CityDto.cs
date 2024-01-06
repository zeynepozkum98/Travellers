using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete.Dtos
{
    public class CityDto:IDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }
      
    }
}
