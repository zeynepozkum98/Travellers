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
    public class ContactMap:CoreMap<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.FirstName).IsRequired();
            builder.Property(x=>x.FirstName).HasMaxLength(50);
            builder.Property(x=>x.Email).IsRequired();
            builder.Property(x=>x.Message).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(500);

            base.Configure(builder);
        }
    }
}
