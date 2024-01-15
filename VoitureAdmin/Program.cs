using BLL.Services;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace VoitureAdmin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MyDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnexionString")));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<CompteService>();
            builder.Services.AddScoped<VehiculeService>();
            builder.Services.AddScoped<DemandeService>();


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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}