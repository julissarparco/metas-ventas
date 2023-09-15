using AutoMapper;
using BCP.Distributed.Config;
using BCP.META.Application.Service.Classes;
using BCP.META.Application.Service.Interfaces;
using BCP.META.Infrastructure.UnitOfWork.Classes;
using BCP.META.Infrastructure.UnitOfWork.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IAgenciaService, AgenciaService>();
builder.Services.AddScoped<IProductoComercialService, ProductoComercialService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IAsesorComercialService, AsesorComercialService>();
builder.Services.AddScoped<IMetaMensualService, MetaMensualService>();
builder.Services.AddSingleton<IUnitOfWork>(new UnitOfWork(builder.Configuration.GetConnectionString("BD_BCP")));

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<SimpleMapping>();
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((c) =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "BCP - API",
            Description = "API para test del BCP",
            Version = "v1"
        }
    );

    var xmlfiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
    xmlfiles.ForEach(xmlfile => c.IncludeXmlComments(xmlfile));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
