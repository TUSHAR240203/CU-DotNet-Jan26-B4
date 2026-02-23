using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingLibrary
{
    public class Class1
    {
        public static string GetGreeting(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Hello, Guest!";
            }
            else
            {
                return "Hello, " + name + "!";
            }
        }
    }
}