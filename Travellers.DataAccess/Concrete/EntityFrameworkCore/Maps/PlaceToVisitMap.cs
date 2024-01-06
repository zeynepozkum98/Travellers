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
    public class PlaceToVisitMap:CoreMap<PlaceToVisit>
    {
        public override void Configure(EntityTypeBuilder<PlaceToVisit> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PlaceToVisitName).IsRequired();
            builder.Property(x=>x.PlaceToVisitName).HasMaxLength(500);
            builder.Property(x=>x.Period).IsRequired();
            builder.Property(x=>x.Period).HasMaxLength(500);
            builder.Property(x=>x.Description).IsRequired();
            builder.Property(x=>x.Description).HasMaxLength(500);
            builder.Property(x=>x.Image).IsRequired();
            builder.Property(x=>x.Price).IsRequired();
            builder.Property(x=>x.StartingPoint).IsRequired();
            builder.Property(x=>x.StartingPoint).HasMaxLength(500);
            builder.Property(x=>x.TourDuration).IsRequired();
            builder.Property(x => x.TourDuration).HasMaxLength(200);
            builder.Property(x=>x.TypeOfTransportation).IsRequired();
            builder.Property(x=>x.TypeOfTransportation).HasMaxLength(500);

            
            base.Configure(builder);
        }
    }
}
