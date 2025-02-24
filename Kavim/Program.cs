using Kavim.Api.MiddelWare;
using Kavim.Core;
using Kavim.Core.classes;
using Kavim.Core.repsitory;
using Kavim.Core.Services;
using Kavim.Data.data;
using Kavim.Data.repsitions;
using Kavim.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStationService, StationService>();
builder.Services.AddScoped<IStreetService, StreetService>();
builder.Services.AddScoped<IManager, Manager>();
builder.Services.AddScoped<IRepository<Station>, StationReository>();
builder.Services.AddScoped<IRepository<Street>, StreetRepository>();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<IRepository<Bus>, BusRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<IData, DataContext>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCheckDate();
app.MapControllers();
app.Run();
