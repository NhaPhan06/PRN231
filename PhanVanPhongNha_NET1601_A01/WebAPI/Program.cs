using BussinessLogic.IService;
using BussinessLogic.Service;
using DataAccess.IRepository;
using DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();