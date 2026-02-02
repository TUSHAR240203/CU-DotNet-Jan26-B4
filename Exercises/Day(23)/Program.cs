using System;
using System.Text.RegularExpressions;

namespace Day_23_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Divide two numbers
            try
            {
                Console.Write("Enter first number: ");
                int a = int.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                int b = int.Parse(Console.ReadLine());

                int result = a / b;
                Console.WriteLine("Result = " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number format");
            }
            finally
            {
                Console.WriteLine("Operation Completed\n");
            }

            // 2. Array index access
            try
            {
                int[] arr = { 10, 20, 30 };
                Console.Write("Enter array index: ");
                int index = int.Parse(Console.ReadLine());

                Console.WriteLine("Value = " + arr[index]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Index out of range");
            }
            finally
            {
                Console.WriteLine("Operation Completed\n");
            }

            // Student Enrollment
            StudentEnrollment();
        }

        static void StudentEnrollment()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine();

                    if (!Regex.IsMatch(name, "^[A-Z][a-z]{2,}$"))
                        throw new InvalidStudentNameException(
                            "Name must start with Capital letter and have minimum 3 letters");

                    Console.Write("Enter Student Age: ");
                    string ageInput = Console.ReadLine();

                    if (!Regex.IsMatch(ageInput, "^[0-9]+$"))
                        throw new FormatException("Age must contain only digits");

                    int age = Convert.ToInt32(ageInput);

                    if (age < 18 || age > 60)
                        throw new InvalidStudentAgeException(
                            "Age must be between 18 and 60");

                    Console.WriteLine("\nStudent Enrolled Successfully ✅");
                    break;
                }
                catch (Exception ex)
                {
                    Exception wrapped =
                        new Exception("Student Enrollment Failed", ex);

                    Console.WriteLine("\n--- Exception Occurred ---");
                    Console.WriteLine("Message: " + wrapped.Message);
                    Console.WriteLine("Inner Exception: " + wrapped.InnerException.Message);
                    Console.WriteLine("StackTrace: " + wrapped.StackTrace);
                    Console.WriteLine("\nTry Again...\n");
                }
                finally
                {
                    Console.WriteLine("Operation Completed\n");
                }
            }
        }
    }

    class InvalidStudentAgeException : Exception
    {
        public InvalidStudentAgeException(string msg) : base(msg) { }
    }

    class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException(string msg) : base(msg) { }
    }
}
