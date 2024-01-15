using System.Configuration;
using BussinessLogic;
using BussinessLogic.Configuration;
using BussinessLogic.IService;
using BussinessLogic.Middleware;
using BussinessLogic.Service;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", false, true)
    .Build();

builder.Services.AddSingleton<GlobalExceptionMiddleware>();

builder.Services.Configure<AdminAccount>(configuration.GetSection("AdminAccount"));

builder.Services.AddScoped<IAuthenticationService,AuthenticationService>();
builder.Services.AddScoped<IBookingDetailService,BookingDetailService>();
builder.Services.AddScoped<IBookingReservationService,BookingReservationService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IRoomInformationService,RoomInformationService>();
builder.Services.AddScoped<IRoomTypeService,RoomTypeService>();
builder.Services.AddScoped<IBookingDetailRepository,BookingDetailRepository>();
builder.Services.AddScoped<IBookingReservationRepository,BookingReservationRepository>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<IRoomInformationRepository,RoomInformationRepository>();
builder.Services.AddScoped<IRoomTypeRepository,RoomTypeRepository>();

//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();