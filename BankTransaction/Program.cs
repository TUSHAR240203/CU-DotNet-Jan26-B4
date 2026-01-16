using System;

namespace BankTransaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] parts = input.Split('#');

            if (parts.Length < 3)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            string transactionId = parts[0];
            string accountHolder = parts[1];
            string narration = parts[2];

            narration = narration.Trim().ToLower();

            while (narration.Contains("  "))
            {
                narration = narration.Replace("  ", " ");
            }

            bool hasDeposit = narration.Contains("deposit");
            bool hasWithdrawal = narration.Contains("withdrawal");
            bool hasTransfer = narration.Contains("transfer");

            bool hasKeyword = hasDeposit || hasWithdrawal || hasTransfer;

            string standardNarration = "cash deposit successful";

            string category;

            if (!hasKeyword)
            {
                category = "NON-FINANCIAL TRANSACTION";
            }
            else if (narration == standardNarration)
            {
                category = "STANDARD TRANSACTION";
            }
            else
            {
                category = "CUSTOM TRANSACTION";
            }

            Console.WriteLine($"Transaction ID : {transactionId}");
            Console.WriteLine($"Account Holder : {accountHolder}");
            Console.WriteLine($"Narration      : {narration}");
            Console.WriteLine($"Category       : {category}");
        }
    }
}
