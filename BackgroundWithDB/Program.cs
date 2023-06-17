using BackgroundWithDB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("OrderdDb"));

builder.Services.AddHostedService<CleanupService>();


var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
