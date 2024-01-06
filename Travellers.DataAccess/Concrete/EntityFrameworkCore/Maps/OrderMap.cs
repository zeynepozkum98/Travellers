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
	public class OrderMap:CoreMap<Order>
	{
		public override void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasMany(x=>x.WinterHolidayOrders).WithOne(x=> x.Order).HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.ClientSetNull);
			base.Configure(builder);
		}
	}
}
