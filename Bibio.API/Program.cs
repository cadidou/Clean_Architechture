using APPLICATION.service.Adherent;
using APPLICATION.service.emprunt;
using APPLICATION.service.Ouvrages;
using Bibio.API.AutoMapper;
using INFRASTRUCTURE;
using INFRASTRUCTURE.GenericReporistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IAdherentService, AdherentService>();
builder.Services.AddScoped<IouvrageService, OuvrageService>();
builder.Services.AddScoped<IEmpruntService, EmpruntService>();
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
