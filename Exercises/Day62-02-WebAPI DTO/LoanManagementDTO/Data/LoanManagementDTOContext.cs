using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanManagementDTO.Models;

namespace LoanManagementDTO.Data
{
    public class LoanManagementDTOContext : DbContext
    {
        public LoanManagementDTOContext (DbContextOptions<LoanManagementDTOContext> options)
            : base(options)
        {
        }

        public DbSet<LoanManagementDTO.Models.Loan> Loan { get; set; } = default!;
    }
}
