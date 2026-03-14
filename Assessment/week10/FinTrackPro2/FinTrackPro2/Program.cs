using FinTrackPro2.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAppMVC7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<FinTrackPro2Context>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("FinTrackPro2Context")));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Accounts}/{action=Index}/{id?}");

            app.Run();
        }
    }
}