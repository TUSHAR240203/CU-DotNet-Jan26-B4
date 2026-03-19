using System.ComponentModel.DataAnnotations;

namespace CarManagementMVCApp.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public required string Brand { get; set; }

        [Required]
        public required string Model { get; set; }

        [Range(1900, 2100)]
        public int Year { get; set; }

        [Range(1, 999999999)]
        public decimal Price { get; set; }
    }
}