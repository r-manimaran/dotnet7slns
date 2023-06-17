using Microsoft.AspNetCore.Authorization;
using WebApiSecurity;
using WebApiSecurity.Security;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<AppRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{

}).AddJwtBearer();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserPolicy", policy => policy.Requirements.Add(new UserRequirement()));
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole(new []{ "Admin" }));
});

builder.Services.AddSingleton<IAuthorizationHandler, UserHandler>();

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
