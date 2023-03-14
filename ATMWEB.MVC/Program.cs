﻿namespace ATMWEB.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //IConfigurationBuilder configurationBuilder = builder.Configuration
        //    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("secrets.json");

        //builder.Services.AddDbContext<ATM.DAL.Data.AtmDbContext>(options =>
        //        options.UseSqlServer(builder.Configuration.GetConnectionString("myConxStr")));

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=ATMPages}/{action=Index}/{id?}");

        app.Run();
    }
}