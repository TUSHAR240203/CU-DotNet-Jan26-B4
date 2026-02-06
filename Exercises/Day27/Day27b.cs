using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace FileStreamDemo
{
    public class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }

        public string RiskLevel()
        {
            if (InterestRate < 5)
                return "Low";
            if (InterestRate >= 5 && InterestRate <= 10)
                return "Medium";
            return "High";
        }

        public double InterestAmount()
        {
            return (Principal * InterestRate) / 100;
        }
    }

    internal class Day27b
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\LoanDetails.csv";

            // ---------- APPEND MODE ----------
            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("ClientName,Principal,InterestRate");
                }
            }

            Console.Write("Enter Client Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Principal Amount: ");
            double principal = double.Parse(Console.ReadLine());

            Console.Write("Enter Interest Rate: ");
            double rate = double.Parse(Console.ReadLine());

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{name},{principal},{rate}");
            }

            // ---------- READ & PARSE ----------
            List<Loan> loans = new List<Loan>();

            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine(); 
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    double p, r;

                    if (double.TryParse(data[1], out p) &&
                        double.TryParse(data[2], out r))
                    {
                        loans.Add(new Loan
                        {
                            ClientName = data[0],
                            Principal = p,
                            InterestRate = r
                        });
                    }
                }
            }

            // ---------- DISPLAY ----------
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo indianCulture = new CultureInfo("en-IN");


            Console.WriteLine("Loan Adde successfully........");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine($"{"Client",-10}|{"Principal",25}|{"Interest",25}|{"Risk",10}     |");
            Console.WriteLine("------------------------------------------------------------------------------");

            foreach (Loan l in loans)
            {
                Console.WriteLine(
        $"{l.ClientName,-10}|" +
        $"{l.Principal.ToString("C2", indianCulture),25}|" +
        $"{l.InterestAmount().ToString("C2", indianCulture),25}|" +
        $"{l.RiskLevel(),10}     |"
    );
            }
        }
    }
}
