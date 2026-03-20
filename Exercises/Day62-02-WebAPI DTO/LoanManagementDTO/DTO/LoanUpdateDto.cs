using System.ComponentModel.DataAnnotations;

namespace LoanManagementDTO.DTO
{
    public class LoanUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string BorrowerName { get; set; } = string.Empty;

        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }

        [Range(1, 600)]
        public int LoanTermMonths { get; set; }

        public bool IsApproved { get; set; }
    }
}