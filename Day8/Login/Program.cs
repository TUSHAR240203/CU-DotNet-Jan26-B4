using System;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input in format:");
            Console.WriteLine("username|message");
            Console.WriteLine("Example: tushar|Login Successful");

            string input = Console.ReadLine();

            string[] parts = input.Split('|');

            if (parts.Length != 2)
            {
                Console.WriteLine("INVALID INPUT");
                return;
            }

            string userName = parts[0];
            string message = parts[1];

            string cleanMessage = message.Trim().ToLower();

            bool containsSuccessful = cleanMessage.Contains("successful");

            string standardMessage = "login successful";

            string status;

            if (!containsSuccessful)
            {
                status = "LOGIN FAILED";
            }
            else if (cleanMessage.Equals(standardMessage))
            {
                status = "LOGIN SUCCESS";
            }
            else
            {
                status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
            }

            Console.WriteLine($"User     : {userName}");
            Console.WriteLine($"Message  : {cleanMessage}");
            Console.WriteLine($"Status   : {status}");
        }
    }
}

