using Microsoft.AspNetCore.Mvc.Versioning;
using APiVersioningRateLimit.Extensions;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Versioning Startup information
builder.Services.AddVersioning();

//Add RateLimit Information
builder.Services.AddRateLimitingFixedWindow();
builder.Services.AddRateLimitingSlidingWindow();
builder.Services.AddRateLimitingConcurrent();
builder.Services.AddRateLimitingTokenBucket();

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
