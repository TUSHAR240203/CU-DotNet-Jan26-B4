using System.Text;
using System.Globalization;

namespace Assessment_week4_
{
    class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; }

        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }

    class Inpatient : Patient
    {
        public int DaysStayed { get; set; }
        public decimal DailyRate { get; set; }

        public override decimal CalculateFinalBill()
        {
            return BaseFee + (DaysStayed * DailyRate);
        }
    }

    class Outpatient : Patient
    {
        public decimal ProcedureFee { get; set; }

        public override decimal CalculateFinalBill()
        {
            return BaseFee + ProcedureFee;
        }
    }

    class EmergencyPatient : Patient
    {
        public int SeverityLevel { get; set; }

        public override decimal CalculateFinalBill()
        {
            if (SeverityLevel >5) {
                Console.WriteLine("SeverityLevel lies between 1-5");
                return BaseFee;
            }
            else
            {
                return BaseFee * SeverityLevel;
            }
        }
    }

    class HospitalBilling
    {
        List<Patient> patients = new List<Patient>();

        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }

        public void GenerateDailyReport()
            
        {
            Console.OutputEncoding = Encoding.UTF8;
            foreach (Patient p in patients)
            {
                Console.WriteLine(p.Name + " Bill: " + p.CalculateFinalBill().ToString("C2", new CultureInfo("en-IN")));
            }
        }

        public decimal CalculateTotalRevenue()
        {
            decimal total = 0;

            foreach (Patient p in patients)
            {
                total = total + p.CalculateFinalBill();
            }

            return total;
        }

        public int GetInpatientCount()
        {
            int count = 0;

            foreach (Patient p in patients)
            {
                if (p is Inpatient)
                {
                    count++;
                }
            }

            return count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo India = new CultureInfo("en-IN");
            HospitalBilling billing = new HospitalBilling();

            billing.AddPatient(new Inpatient
            {
                Name = "Tushar",
                BaseFee = 1000,
                DaysStayed = 3,
                DailyRate = 2000
            });

            billing.AddPatient(new Outpatient
            {
                Name = "Ekta",
                BaseFee = 800,
                ProcedureFee = 1500
            });

            billing.AddPatient(new EmergencyPatient
            {
                Name = "Kushagra",
                BaseFee = 1200,
                SeverityLevel = 4
            });

            Console.WriteLine("---- Daily Report ----");
            billing.GenerateDailyReport();

            Console.WriteLine();
            Console.WriteLine("Total Revenue: " +
                billing.CalculateTotalRevenue().ToString("C2", new CultureInfo("en-IN")));

            Console.WriteLine("Inpatient Count: " +
                billing.GetInpatientCount());
        }
    }
}
                                                                                              