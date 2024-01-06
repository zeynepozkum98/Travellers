using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Maps;
using Travellers.Entities.Concrete;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Travellers.DataAccess.Concrete.EntityFrameworkCore.Maps
{
    public class CategoryMap:CoreMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.CategoryName).IsRequired();
            builder.Property(x => x.CategoryName).HasMaxLength(100);
            builder.HasMany(x => x.Tours).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.PlaceToVisits).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.FlighTickets).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.Hotels).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.WinterHolidays).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);

            base.Configure(builder);

            // Introducing FOREIGN KEY constraint 'FK_PlaceToVisits_Tours_TourId' on table 'PlaceToVisits' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
           // Could not create constraint or index. See previous errors. hatası
        }
    }
}
