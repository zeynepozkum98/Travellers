using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.DataAccess.EntityFramework;
using Travellers.DataAccess.Abstract;
using Travellers.DataAccess.Concrete.EntityFrameworkCore.Context;
using Travellers.Entities.Concrete;

namespace Travellers.DataAccess.Concrete
{
    public class TourDal : RepositoryBase<Tour>, ITourDal
    {
        public TourDal(TravellersContext context) : base(context)
        {
        }
    }
}
