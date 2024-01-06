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
    public class UserMap:CoreMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(x => x.Orders).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            base.Configure(builder);
        }
    }
}
