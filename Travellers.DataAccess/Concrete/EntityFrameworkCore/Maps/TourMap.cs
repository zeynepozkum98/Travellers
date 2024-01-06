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
    public class TourMap:CoreMap<Tour>
    {
        public override void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.TourName).IsRequired();
            builder.Property(x => x.TourName).HasMaxLength(100);
            builder.HasMany(x=>x.PlaceToVisits).WithOne(x=>x.Tour).HasForeignKey(x=>x.TourId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.Ships).WithOne(x => x.Tour).HasForeignKey(x => x.TourId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.FlightToTickets).WithOne(x => x.Tour).HasForeignKey(x => x.TourId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.WinterHolidays).WithOne(x => x.Tour).HasForeignKey(x => x.TourId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.TourCities).WithOne(x => x.Tour).HasForeignKey(x => x.TourId).OnDelete(DeleteBehavior.ClientSetNull);

            base.Configure(builder);
        }
    }
}
