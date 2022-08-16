using WebApi.Models;
using WebApi.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Configuration;
using Microsoft.Extensions.Options;
using WebApi.Services;
using WebApi.Controllers;
using WebApi.Models;



var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PersonaDatabaseSettings>(
    builder.Configuration.GetSection("PersonaDatabase"));
builder.Services.AddSingleton<PersonaDatabaseSettings>();
builder.Services.AddSingleton<PersonaDatabaseSettings>
    (d => d.GetRequiredService<IOptions<PersonaDatabaseSettings>>().Value);
builder.Services.AddControllers()
    .AddJsonOptions(
    options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<PersonaService>();
builder.Services.AddTransient<PersonaService>();
builder.Services.AddScoped<PersonaService>(); 

builder.Services.AddSwaggerGen();

WebApplication? app = builder.Build();

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

