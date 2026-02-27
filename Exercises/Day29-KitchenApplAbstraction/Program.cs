using System;
using System.Collections.Generic;

abstract class KitchenDevice
{
    public string ModelName { get; set; }
    public int PowerConsumption { get; set; }

    protected KitchenDevice(string modelName, int power)
    {
        ModelName = modelName;
        PowerConsumption = power;
    }

    public abstract void Cook();

    public virtual void Preheat()
    {
        Console.WriteLine("No preheating required");
    }
}

interface ITimer
{
    void SetTimer(int minutes);
}

interface IWiFi
{
    void ConnectWiFi(string network);
}

class Microwave : KitchenDevice, ITimer
{
    public Microwave(string model, int power)
        : base(model, power) { }

    public void SetTimer(int minutes)
    {
        Console.WriteLine($"Microwave timer set for {minutes} minutes");
    }

    public override void Cook()
    {
        Console.WriteLine("Microwave cooking food quickly");
    }
}

class ElectricOven : KitchenDevice, ITimer, IWiFi
{
    public ElectricOven(string model, int power)
        : base(model, power) { }

    public void SetTimer(int minutes)
    {
        Console.WriteLine($"Oven timer set for {minutes} minutes");
    }

    public void ConnectWiFi(string network)
    {
        Console.WriteLine($"Oven connected to WiFi: {network}");
    }

    public override void Preheat()
    {
        Console.WriteLine("Oven is preheating");
    }

    public override void Cook()
    {
        Preheat();
        Console.WriteLine("Oven cooking food evenly");
    }
}

class AirFryer : KitchenDevice
{
    public AirFryer(string model, int power)
        : base(model, power) { }

    public override void Cook()
    {
        Console.WriteLine("Air Fryer cooking food using hot air");
    }
}

class Program
{
    static void Main()
    {
        List<KitchenDevice> devices = new List<KitchenDevice>
        {
            new Microwave("MW-100", 1200),
            new ElectricOven("OV-500", 2000),
            new AirFryer("AF-300", 1500)
        };

        foreach (var device in devices)
        {
            Console.WriteLine("\nDevice: " + device.ModelName);
            device.Cook();

            if (device is IWiFi wifi)
            {
                wifi.ConnectWiFi("Home_WiFi");
            }
        }
    }
}