namespace week2Assessment
{
    internal class Program
    {
        static void Main()
        {
            string[] names = new string[5];
            decimal[] premiums = new decimal[5];

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter name: ");
                names[i] = Console.ReadLine();

                while (names[i] == "")
                {
                    Console.Write("Name cannot be empty. Enter again: ");
                    names[i] = Console.ReadLine();
                }

                Console.Write("Enter premium: ");
                premiums[i] = Convert.ToDecimal(Console.ReadLine());

                while (premiums[i] <= 0)
                {
                    Console.Write("Premium must be greater than 0. Enter again: ");
                    premiums[i] = Convert.ToDecimal(Console.ReadLine());
                }
            }

            decimal total = 0;
            decimal highest = premiums[0];
            decimal lowest = premiums[0];

            for (int i = 0; i < 5; i++)
            {
                total = total + premiums[i];

                if (premiums[i] > highest)
                    highest = premiums[i];

                if (premiums[i] < lowest)
                    lowest = premiums[i];
            }

            decimal average = total / 5;

            Console.WriteLine();
            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("{0,-15}{1,15}{2,15}", "Name", "Premium", "Category");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < 5; i++)
            {
                string category;

                if (premiums[i] < 10000)
                    category = "LOW";
                else if (premiums[i] <= 25000)
                    category = "MEDIUM";
                else
                    category = "HIGH";

                Console.WriteLine(
                    "{0,-15}{1,15:F2}{2,15}",
                    names[i],
                    premiums[i],
                    category
                );
            }

            Console.WriteLine("...");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Total Premium   : {0:F2}", total);
            Console.WriteLine("Average Premium : {0:F2}", average);
            Console.WriteLine("Highest Premium : {0:F2}", highest);
            Console.WriteLine("Lowest Premium  : {0:F2}", lowest);
        }
    }
}
