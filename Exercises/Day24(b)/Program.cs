using System.Collections.Generic;

namespace Day24_b_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double,string> leaderboard = new SortedDictionary<double,string>();
            leaderboard.Add(55.42,"SwiftRace");
            leaderboard.Add(52.10, "SpeedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");
            foreach(var x in leaderboard) {
                Console.WriteLine(x);
                }

            decimal Goldmedal = (decimal)leaderboard.Keys.First();
            Console.WriteLine($"Goldmedal Timming is {Goldmedal}");

            leaderboard.Remove(2);
            leaderboard.Add(54.00, "SteadyEddie");
            Console.WriteLine("Dict after update");
            foreach (var x in leaderboard)
            {
                Console.WriteLine(x);
            }
        }
    }
}
