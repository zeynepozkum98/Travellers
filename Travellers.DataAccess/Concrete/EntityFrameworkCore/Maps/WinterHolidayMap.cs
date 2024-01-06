using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Maps;
using Travellers.Entities.Concrete;

namespace Travellers.DataAccess.Concrete.EntityFrameworkCore.Maps
{
	public class WinterHolidayMap:CoreMap<WinterHoliday>
	{
		public override void Configure(EntityTypeBuilder<WinterHoliday> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasMany(x => x.WinterHolidayOrders).WithOne(x => x.WinterHoliday).HasForeignKey(x => x.WinterHolidayId).OnDelete(DeleteBehavior.ClientSetNull);
			builder.Property(x => x.HotelName).IsRequired();
			builder.Property(x => x.HotelName).HasMaxLength(1000);
			builder.Property(x => x.Region).IsRequired();
			builder.Property(x => x.Region).HasMaxLength(1000);
			builder.Property(x => x.AccommodationType).IsRequired();
			builder.Property(x => x.AccommodationType).HasMaxLength(1000);
			builder.Property(x => x.FacilityAmenities).IsRequired();
			builder.Property(x => x.FacilityAmenities).HasMaxLength(2000);
			builder.Property(x => x.Image).IsRequired();
			builder.Property(x=>x.Price).IsRequired();

			base.Configure(builder);
		}
	}
}
