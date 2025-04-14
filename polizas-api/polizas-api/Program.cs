using polizas_api.Models;
using polizas_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; // Ensure this namespace is included
using Microsoft.Extensions.Configuration; // Ensure this namespace is included

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<projectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"))); // Ensure Microsoft.EntityFrameworkCore.SqlServer package is installed



builder.Services.AddScoped<IUserService, UserServices>();

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
