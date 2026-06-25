/*

    Author: Conor Meade

    Date: 7/13/2023

*/

using StockTracker;
using NBAGraphs;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NBAGraphs.Data;

var builder = WebApplication.CreateBuilder(args);

// connect to postgres db
ConfigurationManager config = builder.Configuration;
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(config.GetConnectionString("DefaultConnection"))
);

// Add specific DataService for getting iex data, DI with IDataService
builder.Services.AddScoped<IDataService, DataService>();

// NBA.com stats API - calls stats.nba.com directly, no API key needed
builder.Services.AddHttpClient<INbaStatsService, NbaStatsService>();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add swagger service, makes executing endpoints easier
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "NBAGraphs API",
            Description = "An ASP.NET Core Web API for gathering NBA data and visualizing it with D3.js",
        });

        // This ensures we get the proper xml file on different OS
        //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Console.WriteLine("swagger");
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ensure we are operating on HTTPS
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
