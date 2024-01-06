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
    public class FlightToTicketMap:CoreMap<FlightToTicket>
    {
        public override void Configure(EntityTypeBuilder<FlightToTicket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.FlightCompany).IsRequired();
            builder.Property(x => x.FlightCompany).HasMaxLength(1000);
            builder.Property(x=>x.DepartureTime).IsRequired();
            builder.Property(x=>x.FlightTime).IsRequired();
            builder.Property(x => x.TransferStatus).IsRequired();
            builder.Property(x => x.TransferStatus).HasMaxLength(500);
            builder.Property(x=>x.LuggageStatus).IsRequired();
            builder.Property(x => x.LuggageStatus).HasMaxLength(500);
            builder.Property(x=>x.Price).IsRequired();

            base.Configure(builder);
        }
    }
}
