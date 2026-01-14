using System;

namespace AccessControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter access log in format:");
            Console.WriteLine("GateCode|UserInitial|AccessLevel|IsActive|Attempts");
            Console.WriteLine("Example: A1|T|6|true|45");

            string input = Console.ReadLine();

            string gateCode = "";
            string userInitialStr = "";
            string accessLevelStr = "";
            string isActiveStr = "";
            string attemptsStr = "";

            int part = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '|')
                {
                    part++;
                    continue;
                }

                if (part == 0) gateCode += input[i];
                else if (part == 1) userInitialStr += input[i];
                else if (part == 2) accessLevelStr += input[i];
                else if (part == 3) isActiveStr += input[i];
                else if (part == 4) attemptsStr += input[i];
            }

            if (part != 4)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            if (gateCode.Length != 2 || !char.IsLetter(gateCode[0]) || !char.IsDigit(gateCode[1]))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            if (userInitialStr.Length != 1 || !char.IsUpper(userInitialStr[0]))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }
            char userInitial = userInitialStr[0];

            if (!byte.TryParse(accessLevelStr, out byte accessLevel) || accessLevel < 1 || accessLevel > 7)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            if (!bool.TryParse(isActiveStr, out bool isActive))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            if (!byte.TryParse(attemptsStr, out byte attempts) || attempts > 200)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            string status;

            if (!isActive)
            {
                status = "ACCESS DENIED – INACTIVE USER";
            }
            else if (attempts > 100)
            {
                status = "ACCESS DENIED – TOO MANY ATTEMPTS";
            }
            else if (accessLevel >= 5)
            {
                status = "ACCESS GRANTED – HIGH SECURITY";
            }
            else
            {
                status = "ACCESS GRANTED – STANDARD";
            }

            Console.WriteLine($"{"Gate".PadRight(10)}: {gateCode}");
            Console.WriteLine($"{"User".PadRight(10)}: {userInitial}");
            Console.WriteLine($"{"Level".PadRight(10)}: {accessLevel}");
            Console.WriteLine($"{"Attempts".PadRight(10)}: {attempts}");
            Console.WriteLine($"{"Status".PadRight(10)}: {status}");
        }
    }
}
