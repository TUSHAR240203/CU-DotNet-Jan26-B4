using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week08assisssment
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DeparmentMultiplier { get; set; }
        public double AttendencePercentage { get; set; }
        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary == 0) throw new InvalidDataException("Base salary is 0");
                decimal Bonus = 0;
                decimal Ratingbonus = 0;
                if (PerformanceRating == 5)
                {
                    Ratingbonus = BaseSalary * 0.25m;
                }
                else if (PerformanceRating == 4)
                {
                    Ratingbonus = BaseSalary * 0.18m;
                }
                else if (PerformanceRating == 3)
                {
                    Ratingbonus = BaseSalary * 0.12m;
                }
                else if (PerformanceRating == 2)
                {
                    Ratingbonus = BaseSalary * 0.05m;
                }
                else if (PerformanceRating == 1)
                {
                    Ratingbonus = BaseSalary * 0;
                }
                else
                {
                    throw new InvalidOperationException("Performance Rating is Out of Range 1-5");
                }
                Bonus += Ratingbonus;


                decimal ExperienceBonus = 0;
                if (YearsOfExperience > 10)
                {
                    ExperienceBonus = BaseSalary * 0.05m;
                }
                else if (YearsOfExperience > 5 && YearsOfExperience < 10)
                {
                    ExperienceBonus = BaseSalary * 0.03m;
                }

                Bonus += ExperienceBonus;

                if (AttendencePercentage < 85)
                {
                    Bonus = Bonus * 0.80m;
                }

                Bonus *= DeparmentMultiplier;

                decimal MaxBonus = BaseSalary * 0.40m;
                if (Bonus > MaxBonus)
                {
                    Bonus = MaxBonus;
                }

                decimal Taxrate = 0m;

                if (Bonus <= 150000)
                {
                    Taxrate = 0.90m;
                }
                else if (Bonus > 150000 && Bonus <= 300000)
                {
                    Taxrate = 0.80m;
                }
                else
                {
                    Taxrate = 0.70m;
                }
                Bonus = Bonus * Taxrate;

                decimal FinalBonus = Bonus;
                return Math.Round(FinalBonus, 2);
            }
        }

    }
}