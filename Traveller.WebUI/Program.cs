using AutoMapper;
using Traveller.WebUI.BasketTransaction;
using Travellers.Business.Abstract;
using Travellers.Business.AutoMapper;
using Travellers.Business.Concrete;
using Travellers.DataAccess.Abstract;
using Travellers.DataAccess.Concrete;
using Travellers.DataAccess.Concrete.EntityFrameworkCore.Context;
using Travellers.Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TravellersContext>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<TravellersContext>();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<ICityDal, CityDal>();
builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IContactDal, ContactDal>();
builder.Services.AddScoped<IContactService,ContactManager>();
builder.Services.AddScoped<IOrderDal, OrderDal>();

builder.Services.AddScoped<IOrderProcessService,OrderProcessManager>();
builder.Services.AddScoped<ITourDal,TourDal>();
builder.Services.AddScoped<ITourService, TourManager>();
builder.Services.AddScoped<IPlaceToVisitDal, PlaceToVisitDal>();
builder.Services.AddScoped<IPlaceToVisitService, PlaceToVisitManager>();
builder.Services.AddScoped<IShipDal, ShipDal>();
builder.Services.AddScoped<IShipService,ShipManager>();
builder.Services.AddScoped<IHotelDal, HotelDal>();
builder.Services.AddScoped<IHotelService,HotelManager>();
builder.Services.AddScoped<IFlightToTicketDal,FlightToTicketDal>();
builder.Services.AddScoped<IFlightToTicketService,FlightToTicketManager>();
builder.Services.AddScoped<IWinterHolidayDal, WinterHolidayDal>();
builder.Services.AddScoped<IWinterHolidayService,WinterHolidayManager>();
builder.Services.AddScoped<IWinterHolidayOrderDal, WinterHolidayOrderDal>();
builder.Services.AddScoped<IAuthService, AuthManager>();

builder.Services.AddTransient<IBasketTransaction, BasketTransaction>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Traveller}/{action=Index}/{id?}");

app.Run();
