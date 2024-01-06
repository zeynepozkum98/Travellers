using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Travellers.Business.Abstract;
using Travellers.Business.AutoMapper;
using Travellers.Business.Concrete;
using Travellers.DataAccess.Abstract;
using Travellers.DataAccess.Concrete;
using Travellers.DataAccess.Concrete.EntityFrameworkCore.Context;
using Travellers.Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(x => x.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(x => true)));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("keykullaniyorumburada"))
    };
});


builder.Services.AddDbContext<TravellersContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<TravellersContext>();
builder.Services.AddAutoMapper(typeof(MapperProfile));


builder.Services.AddScoped<ICityDal, CityDal>();
builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ITourDal,TourDal>();
builder.Services.AddScoped<ITourService, TourManager>();
builder.Services.AddScoped<IPlaceToVisitDal,PlaceToVisitDal>();
builder.Services.AddScoped<IPlaceToVisitService,PlaceToVisitManager>();
builder.Services.AddScoped<IAuthService, AuthManager>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

   
}

app.UseCors();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
