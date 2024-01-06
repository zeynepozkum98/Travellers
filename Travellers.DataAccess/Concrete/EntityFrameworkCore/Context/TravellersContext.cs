using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.DataAccess.Concrete.EntityFrameworkCore.Maps;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class TravellersContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Veri tabanı bağlantı cümlemiz
            optionsBuilder.UseSqlServer(@"Server=localhost;Initial Catalog=TravellerDb;
            Trusted_Connection=true;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder) // Model Configure ayarları
        {
            builder.Entity<TourCity>().HasKey(x=>new {x.TourId,x.CityId});
            builder.Entity<WinterHolidayOrder>().HasKey(x=>new {x.WinterHolidayId,x.OrderId});
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new CityMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new PlaceToVisitMap());
            builder.ApplyConfiguration(new TourMap());
            builder.ApplyConfiguration(new HotelMap());
            builder.ApplyConfiguration(new ShipMap());
            builder.ApplyConfiguration(new FlightToTicketMap());
            builder.ApplyConfiguration(new WinterHolidayMap());
            builder.ApplyConfiguration(new ContactMap());
            builder.ApplyConfiguration(new UserMap());
            
                      

            base.OnModelCreating(builder);
        }
        // Tablolarımızı veritabanına setliyoruz yani aktarıyoruz.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PlaceToVisit> PlaceToVisits { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<FlightToTicket> FlightTickets { get; set; }
        public DbSet<WinterHoliday> WinterHolidays { get; set; }
        public DbSet<TourCity> TourCities { get; set; }
        public DbSet<WinterHolidayOrder> WinterHolidayOrders { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
