using BussinessLogic.IService;
using BussinessLogic.Service;
using DataAccess.IRepository;
using DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IBookingDetailService,BookingDetailService>();
builder.Services.AddTransient<IBookingReservationService,BookingReservationService>();
builder.Services.AddTransient<ICustomerService,CustomerService>();
builder.Services.AddTransient<IRoomInformationService,RoomInformationService>();
builder.Services.AddTransient<IRoomTypeService,RoomTypeService>();
builder.Services.AddTransient<IBookingDetailRepository,BookingDetailRepository>();
builder.Services.AddTransient<IBookingReservationRepository,BookingReservationRepository>();
builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();
builder.Services.AddTransient<IRoomInformationRepository,RoomInformationRepository>();
builder.Services.AddTransient<IRoomTypeRepository,RoomTypeRepository>();


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