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
    public class ShipMap:CoreMap<Ship>
    {
        public override void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.ShipName).IsRequired();
            builder.Property(x => x.ShipName).HasMaxLength(500);
            builder.Property(x=>x.ShipCompany).IsRequired();
            builder.Property(x => x.ShipCompany).HasMaxLength(500);
            builder.Property(x=>x.Region).IsRequired();
            builder.Property(x=>x.Region).HasMaxLength(500);
            builder.Property(x=>x.TourDuration).IsRequired();
            builder.Property(x=>x.TourDuration).HasMaxLength(500);
            builder.Property(x=>x.Period).IsRequired();
            builder.Property(x=>x.Price).IsRequired();
            builder.Property(x=>x.Image).IsRequired();

            base.Configure(builder);
        }
    }
}
