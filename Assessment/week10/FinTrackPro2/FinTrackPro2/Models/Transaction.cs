using FinTrackPro2.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinTrackPro2.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        public double Amount { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        [ValidateNever]
        public Account Account { get; set; }
    }
}