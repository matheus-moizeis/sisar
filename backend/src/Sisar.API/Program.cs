using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sisar.API.ViewModel;
using Sisar.Domain.Entities;
using Sisar.Infra.Context;
using Sisar.Infra.Interfaces;
using Sisar.Infra.Repositories;
using Sisar.Service.DTO;
using Sisar.Service.Interfaces;
using Sisar.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AutoMapper

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Emitente, EmitenteDTO>().ReverseMap();
    cfg.CreateMap<CreateEmitenteViewModel, EmitenteDTO>().ReverseMap();
    cfg.CreateMap<UpdateEmitenteViewModel, EmitenteDTO>().ReverseMap();
});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

#endregion

#region DI

#region Emitente

builder.Services.AddScoped<IEmitenteService, EmitenteService>();
builder.Services.AddScoped<IEmitenteRepository, EmitenteRepository>();

#endregion

#endregion

#region DB

builder.Services.AddSingleton(d => builder.Configuration);
builder.Services.AddDbContext<SisarContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DB_SISAR"]), ServiceLifetime.Transient);

#endregion

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
