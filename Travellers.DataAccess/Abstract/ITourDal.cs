using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.DataAccess.EntityFramework;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.DataAccess.Abstract
{
    public interface ITourDal:IRepository<Tour>
    {
        public List<Tour> TourWithPlaceToVisit() => _set.Include(x => x.TourName).ToList();
        public Tour GetTourWithPlaceToVisitById(int id) => _set.Include(x => x.PlaceToVisits).FirstOrDefault(x => x.Id == id);
    }
}
