using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.DataAccess.EntityFramework;
using Travellers.Entities.Concrete;

namespace Travellers.DataAccess.Abstract
{
    public interface ITourCityDal : IRepository<TourCity>
    {
    }
}
