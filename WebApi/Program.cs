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


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

//builder.Services.AddControllers()
          //      .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.Configure<PersonaSettings>(builder.Configuration.GetSection("PersonaSettings").Get<PersonaSettings>();));
//builder.Configuration.GetSection("PersonaSettings").Get<PersonaSettings>();
builder.Services.Configure<PersonaSettings>(builder.Configuration.GetSection("PersonaSettings"));
builder.Services.AddSingleton<PersonaSettings>
    (d => d.GetRequiredService<IOptions<PersonaSettings>>().Value);
builder.Services.AddControllers()
    .AddJsonOptions(
    options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();

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

