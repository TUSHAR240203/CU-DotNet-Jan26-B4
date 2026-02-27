using System.Security.Cryptography;
using System.Security.Principal;
using System.Text.Unicode;

namespace ClaSWork
{

    class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipleAmount { get; set; }
        public int Tenure { get; set; }

        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipleAmount = 0m;
            Tenure = 0;
        }
        public Loan(string id, string name, decimal Amount, int tenure)
        {
            LoanNumber = id;
            CustomerName = name;
            PrincipleAmount = Amount;
            Tenure = tenure;

        }
        public decimal CalculateEMI()
        {
            decimal interest = PrincipleAmount * 10 / 100 * Tenure;
            decimal totalAmount = PrincipleAmount + interest;
            return totalAmount / (Tenure * 12);
        }
        public override string ToString()
        {
            return $"LoanNumber :{LoanNumber}," +
                $"Customer_Name: {CustomerName}," +
                $"Principal :{PrincipleAmount}," +
                $"Tenure :{Tenure},";
        }


    }
    class HomeLoan : Loan
    {
        public HomeLoan(string loanNo, string name, decimal principal, int tenure)
       : base(loanNo, name, principal, tenure) { }
        public new decimal CalculateEMI()
        {
            decimal interest = PrincipleAmount * 8 / 100 * Tenure;
            decimal processingFee = PrincipleAmount * 1 / 100;
            decimal totalAmount = PrincipleAmount + interest + processingFee;
            return totalAmount / (Tenure * 12);
        }

    }
    class CarLoan : Loan
    {
        public CarLoan(string loanNo, string name, decimal principal, int tenure)
       : base(loanNo, name, principal, tenure) { }
        public new decimal CalculateEMI()
        {
            decimal newPrincipal = PrincipleAmount + 15000;
            decimal interest = newPrincipal * 9 / 100 * Tenure;
            decimal totalAmount = newPrincipal + interest;
            return totalAmount / (Tenure * 12);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Loan l1= new Loan("151","Kush",100000,5);
            //CarLoan c1 = new CarLoan();
            //Console.WriteLine(c1.CalculateEMI(100000, 2));


            Loan[] arr = new Loan[4] {
            new HomeLoan("H1", "Kush", 100000, 10),
    new HomeLoan("H2", "K2", 100000, 10),
    new CarLoan("C1", "k3",100000 , 10),
    new CarLoan("C2", "k4", 100000, 10)
            };

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            foreach (Loan i in arr)
            {
                Console.WriteLine($"EMI = {i.CalculateEMI():C2}");
            }

        }
    }
}
