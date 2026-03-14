using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinTrackPro2.Models;

namespace FinTrackPro2.Data
{
    public class FinTrackPro2Context : DbContext
    {
        public FinTrackPro2Context (DbContextOptions<FinTrackPro2Context> options)
            : base(options)
        {
        }

        public DbSet<FinTrackPro2.Models.Transaction> Transaction { get; set; } = default!;
        public DbSet<FinTrackPro2.Models.Account> Account { get; set; } = default!;
    }
}
