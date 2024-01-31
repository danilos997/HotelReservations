using Application.Services.Reservations;
using Infrastructure.AppContext;
using Infrastructure.Repositories.Hotel;
using Infrastructure.Repositories.Reservation;
using Infrastructure.Repositories.Visitor;
using Infrastructure.Services.Hotel;
using Infrastructure.Services.Visitor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HotelDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddTransient<IHotelRepository, HotelRepository>();
builder.Services.AddTransient<IVisitorRepository, VisitorRepository>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();
builder.Services.AddTransient<IHotelService, HotelService>();
builder.Services.AddTransient<IVisitorService, VisitorService>();
builder.Services.AddTransient<IReservationService, ReservationService>();

builder.Services.AddCors(settings => settings.AddPolicy("Cors", policy =>
{
    policy.WithOrigins("*").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
}));

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
    db.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
