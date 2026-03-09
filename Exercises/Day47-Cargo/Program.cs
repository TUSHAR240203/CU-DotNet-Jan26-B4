using System;
using System.Collections.Generic;
using System.Linq;

namespace Week09Work
{
    public class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }

        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }
    }

    public class Container
    {
        public string ContainerID { get; set; }
        public List<Item> items = new List<Item>();

        public Container(string id, List<Item> item)
        {
            ContainerID = id;
            items = new List<Item>(item);
        }
    }

    internal class Program
    {
        static void FindHeavyContainers(List<List<Container>> container, double threshhold)
        {
            var exceed = container
                .SelectMany(y => y)
                .Select(x => new
                {
                    ID = x.ContainerID,
                    totalWeight = x.items.Sum(y => y.Weight)
                })
                .Where(x => x.totalWeight > threshhold);

            foreach (var i in exceed)
            {
                Console.WriteLine($"{i.ID}");
            }
        }

        static void getItemsByCount(Container c)
        {
            var cnt = c.items
                .GroupBy(y => y.Category)
                .Select(x => new
                {
                    x.Key,
                    cnt = x.Count()
                })
                .ToDictionary(x => x.Key, y => y.cnt);

            foreach (var i in cnt)
            {
                Console.WriteLine(i.Key + " " + i.Value);
            }
        }

        static void FlattenAndSortShipment(List<List<Container>> container)
        {
            var flaten = container
                .SelectMany(x => x)
                .SelectMany(x => x.items)
                .GroupBy(x => x.Name)
                .Select(x => x.First())
                .OrderBy(x => x.Category)
                .ThenByDescending(y => y.Weight)
                .ToList();

            foreach (var i in flaten)
            {
                Console.WriteLine($"{i.Category} | {i.Name}");
            }
        }

        static void Main(string[] args)
        {
            var contain = new List<Container>
            {
                new Container("C1", new List<Item>
                {
                    new Item("Vase", 3.0, "Decor"),
                    new Item("Mirror", 12.0, "Decor")
                }),
                new Container("C002", new List<Item>
                {
                    new Item("Apple", 0.2, "Food"),
                    new Item("Banana", 0.2, "Food"),
                    new Item("Milk", 1.0, "Food"),
                    new Item("Apple", 0.2, "Food")
                }),
                new Container("C003", new List<Item>
                {
                    new Item("Table", 15.0, "Furniture"),
                    new Item("Chair", 7.5, "Furniture")
                })
            };

            List<List<Container>> demo = new List<List<Container>>();
            demo.Add(contain);

            FindHeavyContainers(demo, 10);
            FlattenAndSortShipment(demo);

            foreach (var i in contain)
            {
                getItemsByCount(i);
            }
        }
    }
}