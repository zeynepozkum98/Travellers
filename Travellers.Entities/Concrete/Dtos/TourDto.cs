using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete.Dtos
{
    public class TourDto:IDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string TourName { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }

    }
}
