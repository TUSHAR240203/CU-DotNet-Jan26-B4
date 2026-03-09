using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo2
{
    class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }
    }

    internal class Program
    {
        public List<CreatorStats> EngagementBoard = new List<CreatorStats>();

        public void RegisterCreator(CreatorStats record)
        {
            EngagementBoard.Add(record);
        }

        public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double threshold)
        {
            var data = records
                .Select(x => new
                {
                    Name = x.CreatorName,
                    cnt = x.WeeklyLikes.Count(y => y >= threshold)
                })
                .ToDictionary(x => x.Name, y => y.cnt);

            return data;
        }

        public double CalculateAverageLikes()
        {
            var data = EngagementBoard.Select(x => x.WeeklyLikes.Average());
            return data.Average();
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            int choice = 0;

            while (choice != 4)
            {
                Console.WriteLine("Enter Choice to Proceed");
                Console.WriteLine("1. Register Creator");
                Console.WriteLine("2. Get Top Post Counts");
                Console.WriteLine("3. Calculate Average Likes");
                Console.WriteLine("4. Exit");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Creator Name:");
                        string name = Console.ReadLine();

                        double[] week = new double[4];
                        Console.WriteLine("Enter 4 Weekly Likes Values:");

                        for (int i = 0; i < 4; i++)
                        {
                            double.TryParse(Console.ReadLine(), out double result);
                            week[i] = result;
                        }

                        CreatorStats creator = new CreatorStats
                        {
                            CreatorName = name,
                            WeeklyLikes = week
                        };

                        p.RegisterCreator(creator);
                        break;

                    case 2:
                        Console.WriteLine("Enter the threshold value:");
                        double.TryParse(Console.ReadLine(), out double threshold);

                        var resultData = p.GetTopPostCounts(p.EngagementBoard, threshold);

                        foreach (var i in resultData)
                        {
                            Console.WriteLine(i.Key + " - " + i.Value);
                        }
                        break;

                    case 3:
                        if (p.EngagementBoard.Count > 0)
                        {
                            Console.WriteLine(p.CalculateAverageLikes());
                        }
                        else
                        {
                            Console.WriteLine("No creator data available.");
                        }
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}