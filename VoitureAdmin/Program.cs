using BLL.Mapper;
using BLL.Services;
using DAL;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            builder.Services.AddScoped<ICompteService, CompteService>();
            builder.Services.AddScoped<IDemandeService , DemandeService>();
            builder.Services.AddScoped<IVehiculeService, VehiculeService>();
            builder.Configuration.AddJsonFile("appsettings.json");
            var firebaseConfigSection = builder.Configuration.GetSection("FirebaseConfig");
            if (firebaseConfigSection != null && !string.IsNullOrEmpty(firebaseConfigSection.Value))
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromJson(firebaseConfigSection.Value)
                });
            }

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Compte/Login"; 
                options.AccessDeniedPath = "/Compte/Acces"; 
            });


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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Compte}/{action=Login}/{id?}");

            app.Run();
        }
    }
}