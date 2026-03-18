using Microsoft.EntityFrameworkCore;
using WealthTrack.Models;

namespace WealthTrack.Data
{
    public class WealthTrackContext : DbContext
    {
        public WealthTrackContext(DbContextOptions<WealthTrackContext> options)
            : base(options)
        {
        }

        public DbSet<Investment> Investments { get; set; }
    }
}