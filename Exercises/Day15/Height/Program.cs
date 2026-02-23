using System;

namespace Height
{
    class HeightData
    {
        public int Feet { get; set; }
        public double Inches { get; set; }

        public HeightData()
        {
            Feet = 0;
            Inches = 0.0;
        }

        public HeightData(int feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }

        public HeightData AddHeights(HeightData h2)
        {
            int totalFeet = Feet + h2.Feet;
            double totalInches = Inches + h2.Inches;

            if (totalInches >= 12)
            {
                totalFeet = totalFeet + (int)(totalInches / 12);
                 totalInches = totalInches % 12;
            }

            return new HeightData(totalFeet, totalInches);
        }

        public override string ToString()
        {
            return "Height - " + Feet + " feet " + Inches + " inches";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            HeightData person1 = new HeightData(5, 6.5);
            HeightData person2 = new HeightData(5, 7.5);

            HeightData totalHeight = person1.AddHeights(person2);

            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(totalHeight);
        }
    }
}
