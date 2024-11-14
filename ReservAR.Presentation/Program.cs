using Microsoft.OpenApi.Models;
using ReservAR.Application;
using ReservAR.Infraestructure;
using ReservAR.Presentation;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();


builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfraestructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseExceptionHandler();
app.UseStatusCodePages();


app.UseAuthorization();

app.MapControllers();

//app.Seed();

app.Run();
