using FluentValidation;
using Institution.Infrastructure.Context;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Institution.Domain.Interfaces;
using Institution.Infrastructure.Repositories;
using Institution.API.Middlewares;
using Institution.Application.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddValidatorsFromAssemblyContaining<MunicipalityValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<SerctorValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();