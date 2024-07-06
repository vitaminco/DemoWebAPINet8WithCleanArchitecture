//using để sử dụng Infrastrure
using Infrastrure.DependencyInjection;
using Infrastrure.Handlers.PeopleHandler;
using WebAPI.Configurations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//sử dụng ServiceContainer
builder.Services.InFrastrutureServics(builder.Configuration);
//Sử dụng automapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
//Sử dụng MediatR 
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPeopleListHandlers).Assembly));

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
