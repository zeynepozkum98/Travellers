using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.DataAccess.EntityFramework;
using Travellers.Entities.Concrete;

namespace Travellers.DataAccess.Abstract
{
	public interface IWinterHolidayDal:IRepository<WinterHoliday>
	{
		public List<WinterHoliday> WinterHolidayWithTour() => _set.Include(x => x.Tour).ToList();
		public WinterHoliday GetWinterHolidayWithTourById(int id) => _set.Include(x => x.Tour).FirstOrDefault(x => x.Id == id);
	}
}
