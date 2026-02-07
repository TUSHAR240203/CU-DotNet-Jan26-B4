using System;
using System.Collections.Generic;
using System.IO;

namespace Week5Assessment
{
    public interface ILoggable
    {
        void SaveLog(string message);
    }

    public class RestrictedDestinationException : Exception
    {
        public string DeniedLocation { get; set; }
        public RestrictedDestinationException(string location) : base($"Shipment destination '{location}' is restricted")
        {
            DeniedLocation = location;
        }
    }

    public class InsecurePackagingException : Exception
    {
        public InsecurePackagingException() : base("Fragile shipment is not reinforced")
        {
        }
    }

    public class LogManager : ILoggable
    {
        public string logFile;

        public LogManager()
        {
            string dir = @"../../../";

            if (!Directory.Exists(dir))
            {
                Console.WriteLine("Directory not found");
            }

            string file = "shipment_audit.log";

            logFile = dir + file;
        }

        public void SaveLog(string message)
        {
            using StreamWriter sw = new StreamWriter(logFile, true);
            sw.WriteLine(message);
        }
    }

    public abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }
        public bool IsFragile { get; set; }
        public bool IsReinforced { get; set; }

        protected Shipment(string trackingId, double weight, string destination)
        {
            TrackingId = trackingId;
            Weight = weight;
            Destination = destination;
        }

        public abstract void ProcessShipment();
    }

    public class ExpressShipment : Shipment
    {
        public ExpressShipment(string trackingId, double weight, string destination) : base(trackingId, weight, destination)
        {
        }

        public override void ProcessShipment()
        {
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight must be greater than zero");
            }

            if (Destination == "North Pole" || Destination == "Unknown Island")
            {
                throw new RestrictedDestinationException(Destination);
            }

            if (IsFragile && !IsReinforced)
            {
                throw new InsecurePackagingException();
            }

            Console.WriteLine($"Express shipment {TrackingId} processed successfully");
        }
    }

    public class HeavyFreight : Shipment
    {
        public bool HasHeavyLiftPermit { get; set; }

        public HeavyFreight(string trackingId, double weight, string destination, bool hasPermit) : base(trackingId, weight, destination)
        {
            HasHeavyLiftPermit = hasPermit;
        }

        public override void ProcessShipment()
        {
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight must be greater than zero");
            }

            if (Destination == "North Pole" || Destination == "Unknown Island")
            {
                throw new RestrictedDestinationException(Destination);
            }

            if (Weight > 1000 && !HasHeavyLiftPermit)
            {
                throw new Exception("Heavy Lift permit required");
            }

            if (IsFragile && !IsReinforced)
            {
                throw new InsecurePackagingException();
            }

            Console.WriteLine($"Heavy freight {TrackingId} processed successfully");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager logManager = new LogManager();

            List<Shipment> shipments = new List<Shipment>()
            {
                new ExpressShipment("EXP001", 10, "USA"),
                new ExpressShipment("EXP002", -5, "UK"),
                new ExpressShipment("EXP003", 5, "North Pole") { IsFragile = true, IsReinforced = false },
                new HeavyFreight("HFT001", 1500, "India", false),
                new HeavyFreight("HFT002", 1200, "Germany", true) { IsFragile = true, IsReinforced = true }
            };

            foreach (Shipment shipment in shipments)
            {
                try
                {
                    shipment.ProcessShipment();
                    logManager.SaveLog($"Shipment {shipment.TrackingId} processed successfully");
                }
                catch (RestrictedDestinationException ex)
                {
                    logManager.SaveLog($"Security Alert: {ex.DeniedLocation}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    logManager.SaveLog($"Data Entry Error: {ex.Message}");
                }
                catch (InsecurePackagingException ex)
                {
                    logManager.SaveLog($"Packaging Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    logManager.SaveLog($"General Error: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"Processing attempt finished for ID: {shipment.TrackingId}");
                }
            }

            Console.WriteLine("All shipments processed. Check 'shipment_audit.log'");
        }
    }
}
