using Microsoft.Extensions.Hosting;
using SmartBank.LogTrack.Models;

namespace SmartBank.LogTrack.Services
{
    public class GpsBackgroundService : BackgroundService
    {
        private static readonly Random _rand = new Random();
        private static int _idCounter = 1;

        public static List<gps> GpsDataStore = new List<gps>();

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var data = new gps
                {
                    Id = _idCounter++,
                    TruckId = "TRK1",
                    Latitude = 30.7333 + (_rand.NextDouble() - 0.5) / 100,
                    Longitude = 76.7794 + (_rand.NextDouble() - 0.5) / 100,
                    Speed = _rand.Next(40, 90),
                    Timestamp = DateTime.UtcNow
                };

                GpsDataStore.Add(data);

                Console.WriteLine($"GPS Updated: {data.TruckId} | {data.Latitude}, {data.Longitude} | {data.Timestamp}");

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}