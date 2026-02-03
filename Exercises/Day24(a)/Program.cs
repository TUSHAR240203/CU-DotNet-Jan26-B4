using System.Collections;

namespace Day24_a_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "Alice");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");

            foreach (int i in employeeTable.Keys)
            {
                Console.WriteLine(i);
            }

            if (!employeeTable.ContainsKey(105))
                employeeTable.Add(105, "Edward");
            else
                Console.WriteLine("ID already exists.");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("After Checking");
            foreach (int i in employeeTable.Keys)
            {
                Console.WriteLine(i);
            }
            
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("Check Again");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            
            if (!employeeTable.ContainsKey(105))
                employeeTable.Add(105, "Edward");
            else
                Console.WriteLine("ID already exists.");

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            
            string empName = (string)employeeTable[102];
            Console.WriteLine("Employee 102: " + empName);
            
            Console.WriteLine("-------------------------------------------------------------------------------------------"); Console.WriteLine("-------------------------------------------------------------------------------------------");
            
            foreach (DictionaryEntry entry in employeeTable)
                Console.WriteLine("ID: " + entry.Key + ", Name: " + entry.Value);
            
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            
            employeeTable.Remove(103);
            Console.WriteLine("Total Employees: " + employeeTable.Count);
        }
    }
}
