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
    public class CityMap:CoreMap<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.CityName).IsRequired();
            builder.Property(x => x.CityName).HasMaxLength(100);
            builder.HasMany(x => x.TourCities).WithOne(x => x.City).HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.Hotels).WithOne(x => x.City).HasForeignKey(x => x.CityId);
            builder.HasMany(x => x.FlightTickets).WithOne(x => x.City).HasForeignKey(x => x.CityId);
            base.Configure(builder);
        }
    }
}
