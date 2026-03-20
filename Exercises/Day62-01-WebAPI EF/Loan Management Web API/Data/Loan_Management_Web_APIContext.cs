using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loan_Management_Web_API.Models;

namespace Loan_Management_Web_API.Data
{
    public class Loan_Management_Web_APIContext : DbContext
    {
        public Loan_Management_Web_APIContext (DbContextOptions<Loan_Management_Web_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Loan_Management_Web_API.Models.Loan> Loan { get; set; } = default!;
    }
}
