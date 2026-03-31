using SmartBank.LogTrack.Models;

namespace SmartBank.LogTrack.Services
{
    public class TrackingService
    {
        public List<gps> GetAll()
        {
            return GpsBackgroundService.GpsDataStore;
        }

        public gps GetLatest()
        {
            if (GpsBackgroundService.GpsDataStore.Count == 0)
            {
                return null;
            }

            return GpsBackgroundService.GpsDataStore.Last();
        }

        public List<gps> GetHistory()
        {
            return GpsBackgroundService.GpsDataStore
                .OrderByDescending(x => x.Timestamp)
                .ToList();
        }
    }
}