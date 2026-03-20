using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Loan_Management_Web_API.Data;

namespace Loan_Management_Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Loan_Management_Web_APIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Loan_Management_Web_APIContext") ?? throw new InvalidOperationException("Connection string 'Loan_Management_Web_APIContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
        }
    }
}
