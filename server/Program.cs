using BL;
using DL;
using Entities_.Models;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddTransient<IEmployeeBL, EmployeeBL>();
builder.Services.AddTransient<IEmployeeDL, EmployeeDL>();
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DB");
builder.Services.AddDbContext<project_oneContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.Run();
