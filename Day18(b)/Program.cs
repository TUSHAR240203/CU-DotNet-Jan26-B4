using System;

namespace Week3
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYears { get; set; }

        public Employee(int id, string name, decimal salary, int experience)
        {
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = salary;
            ExperienceInYears = experience;
        }

        public decimal CalculateAnnualSalary()
        {
            return BasicSalary * 12;
        }

        public void DisplayEmployeeDetails(decimal annualSalary)
        {
            Console.WriteLine($"ID: {EmployeeId}");
            Console.WriteLine($"Name: {EmployeeName}");
            Console.WriteLine($"Annual Salary: {annualSalary}");
            Console.WriteLine();
        }
    }

    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int id, string name, decimal salary, int experience)
            : base(id, name, salary, experience) { }

        public new decimal CalculateAnnualSalary()
        {
            decimal hra = BasicSalary * 0.20m;
            decimal sa = BasicSalary * 0.10m;
            decimal bonus = ExperienceInYears >= 5 ? 50000 : 0;

            decimal monthly = BasicSalary + hra + sa;
            return (monthly * 12) + bonus;
        }
    }

    class ContractEmployee : Employee
    {
        public int ContractDurationInMonths { get; set; }

        public ContractEmployee(int id, string name, decimal salary, int experience, int months)
            : base(id, name, salary, experience)
        {
            ContractDurationInMonths = months;
        }

        public new decimal CalculateAnnualSalary()
        {
            decimal bonus = ContractDurationInMonths >= 12 ? 30000 : 0;
            return (BasicSalary * 12) + bonus;
        }
    }

    class InternEmployee : Employee
    {
        public InternEmployee(int id, string name, decimal stipend, int experience)
            : base(id, name, stipend, experience) { }

        public new decimal CalculateAnnualSalary()
        {
            return BasicSalary * 12;
        }
    }

    internal class Day18_02
    {
        static void Main(string[] args)
        {
            PermanentEmployee p =
                new PermanentEmployee(1, "Rohit", 40000, 6);

            ContractEmployee c =
                new ContractEmployee(2, "Karan", 35000, 2, 14);

            InternEmployee i =
                new InternEmployee(3, "Pooja", 40000, 6);

            p.DisplayEmployeeDetails(p.CalculateAnnualSalary());
            c.DisplayEmployeeDetails(c.CalculateAnnualSalary());
            i.DisplayEmployeeDetails(i.CalculateAnnualSalary());
        }
    }
}
