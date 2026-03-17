using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Borrower Name is required")]
        [Display(Name = "Borrower Name")]
        public string BorrowerName { get; set; }

        public string LenderName { get; set; }

        [Range(1, 500000, ErrorMessage = "Amount must be between 1 and 500000")]
        public double Amount { get; set; }

        public bool IsSettled { get; set; }
    }
}