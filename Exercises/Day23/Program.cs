using System;

class Program
{
    static void Main()
    {
        DivideNumbers();
        ConvertToInt();
        AccessArray();        
        GetStudentDetails();
    }

    static void DivideNumbers()
    {
        try
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            int result = a / b;
            Console.WriteLine("Result: " + result);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Cannot divide by zero");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Operation Completed\n");
        }
    }

    static void ConvertToInt()
    {
        try
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + num);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: Invalid number format");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Operation Completed\n");
        }
    }

    static void AccessArray()
    {
        try
        {
            int[] arr = { 10, 20, 30 };

            Console.Write("Enter array index: ");
            int index = int.Parse(Console.ReadLine());

            Console.WriteLine("Value: " + arr[index]);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Error: Index out of range");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Operation Completed\n");
        }
    }

    static void GetStudentDetails()
    {
        try
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidStudentNameException("Student name cannot be empty");
            }

            int age = 0;
            bool validAge = false;

            while (!validAge)
            {
                try
                {
                    Console.Write("Enter Student Age: ");
                    age = int.Parse(Console.ReadLine());

                    if (age < 18 || age > 60)
                    {
                        throw new InvalidStudentAgeException("Age must be between 18 and 60");
                    }

                    validAge = true;
                }
                catch (InvalidStudentAgeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("\nStudent Registered Successfully");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
        }
        catch (Exception ex)
        {
            Exception wrappedException =
                new Exception("Student enrollment failed", ex);

            Console.WriteLine("\nException Message:");
            Console.WriteLine(wrappedException.Message);

            Console.WriteLine("\nInner Exception Message:");
            Console.WriteLine(wrappedException.InnerException.Message);

            Console.WriteLine("\nStack Trace:");
            Console.WriteLine(wrappedException.StackTrace);

            Console.WriteLine("\nInner Exception Object:");
            Console.WriteLine(wrappedException.InnerException);
        }
    }
}

class InvalidStudentAgeException : Exception
{
    public InvalidStudentAgeException(string message) : base(message)
    {
    }
}

class InvalidStudentNameException : Exception
{
    public InvalidStudentNameException(string message) : base(message)
    {
    }
}