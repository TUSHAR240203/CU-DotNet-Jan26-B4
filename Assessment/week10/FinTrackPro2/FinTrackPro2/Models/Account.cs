using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinTrackPro2.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string AccountHolder { get; set; }

        public double Balance { get; set; }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}