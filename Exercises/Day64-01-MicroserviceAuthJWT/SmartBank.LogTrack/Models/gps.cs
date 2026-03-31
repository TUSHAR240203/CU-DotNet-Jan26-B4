namespace SmartBank.LogTrack.Models
{
    public class gps
    {
        public int Id { get; set; } 
        public string TruckId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }
        public DateTime Timestamp { get; set; }
    }
}