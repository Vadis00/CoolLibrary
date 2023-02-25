using CoolLibrary.BLL.Service;
using CoolLibrary.DAL;
using CoolLibrary.DAL.SeedData;
using CoolLibrary.WebAPI.AppConfigurationExtension;
using CoolLibrary.WebAPI.Middleware;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

AppConfigurationExtension.RegisterServices(builder.Services, builder.Configuration);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("MyDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(
    options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
);

app.UseMiddleware<ExceptionMiddleware>(app.Logger);

var scope = app.Services.CreateAsyncScope();
var dbContext = scope.ServiceProvider.GetService<DataContext>();
await SeedData.Initialization(dbContext);

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