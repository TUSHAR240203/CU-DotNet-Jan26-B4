namespace Loan_Management_Web_API.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string BorrowerName { get; set; }
        public decimal Amount { get; set; }
        public int LongTermMonths { get; set; }
        public bool IsApproved { get; set; }

    }
}
