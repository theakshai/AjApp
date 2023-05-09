using AjApp.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AjApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.
            builder.Services.AddAuthentication
           (x =>
           {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
           }).AddJwtBearer(x =>
           {
               x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
               {
                   ValidIssuer = "https://localhost:7020",
                   ValidAudience = "https://localhost:7166",
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsAKeyForTestingJWT"!)),
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
               };
           });
            builder.Services.AddAuthorization();
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AuthUserContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB"))
                );

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}