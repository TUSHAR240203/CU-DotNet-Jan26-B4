using Microsoft.EntityFrameworkCore;
using WealthTrack.Data;

namespace WealthTrack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WealthTrackContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("WealthTrackContext")
                    ?? throw new InvalidOperationException("Connection string 'WealthTrackContext' not found.")
                ));

            builder.Services.AddControllersWithViews();

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
                pattern: "{controller=Investments}/{action=Index}/{id?}");

            app.Run();
        }
    }
}