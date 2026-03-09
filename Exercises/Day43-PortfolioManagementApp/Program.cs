using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InvestmentTrackerApp
{
    interface IRiskLevel
    {
        string GetRiskCategory();
    }

    interface IPrintable
    {
        string GetReportText();
    }

    class FinancialInputException : Exception
    {
        public FinancialInputException(string message) : base(message) { }
    }

    abstract class Asset
    {
        private int units;
        private decimal buyPrice;
        private decimal currentPrice;
        private string currencyCode;

        public string AssetId { get; set; }
        public string AssetName { get; set; }
        public DateOnly BoughtOn { get; set; }

        public string Currency
        {
            get { return currencyCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 3)
                    throw new FinancialInputException("Invalid Currency");
                currencyCode = value.ToUpper();
            }
        }

        public int Quantity
        {
            get { return units; }
            set
            {
                if (value < 0)
                    throw new FinancialInputException("Invalid Quantity");
                units = value;
            }
        }

        public decimal PurchasePrice
        {
            get { return buyPrice; }
            set
            {
                if (value < 0)
                    throw new FinancialInputException("Invalid Price");
                buyPrice = value;
            }
        }

        public decimal MarketPrice
        {
            get { return currentPrice; }
            set
            {
                if (value < 0)
                    throw new FinancialInputException("Invalid Price");
                currentPrice = value;
            }
        }

        public virtual decimal GetCurrentWorth()
        {
            return MarketPrice * Quantity;
        }

        public virtual string GetShortInfo()
        {
            return $"{AssetId} | {AssetName} | {Quantity} | {Currency}";
        }
    }

    class StockAsset : Asset, IRiskLevel, IPrintable
    {
        public string GetRiskCategory()
        {
            return "High";
        }

        public string GetReportText()
        {
            return $"{AssetId} | Equity | {AssetName} | {GetCurrentWorth():C}";
        }
    }

    class BondAsset : Asset, IRiskLevel, IPrintable
    {
        public string GetRiskCategory()
        {
            return "Medium";
        }

        public string GetReportText()
        {
            return $"{AssetId} | Bond | {AssetName} | {GetCurrentWorth():C}";
        }
    }

    class DepositAsset : Asset, IRiskLevel, IPrintable
    {
        public string GetRiskCategory()
        {
            return "Low";
        }

        public string GetReportText()
        {
            return $"{AssetId} | FixedDeposit | {AssetName} | {GetCurrentWorth():C}";
        }
    }

    class FundAsset : Asset, IRiskLevel, IPrintable
    {
        public string GetRiskCategory()
        {
            return "High";
        }

        public string GetReportText()
        {
            return $"{AssetId} | MutualFund | {AssetName} | {GetCurrentWorth():C}";
        }
    }

    class TradeEntry
    {
        public string TradeId { get; set; }
        public string AssetId { get; set; }
        public string ActionType { get; set; }
        public int Units { get; set; }
        public DateOnly TradeDate { get; set; }
    }

    class AssetPortfolio
    {
        private List<Asset> assetList = new List<Asset>();
        private Dictionary<string, Asset> assetMap = new Dictionary<string, Asset>();

        public void AddAsset(Asset asset)
        {
            if (assetMap.ContainsKey(asset.AssetId))
                throw new FinancialInputException("Duplicate Instrument ID");

            assetList.Add(asset);
            assetMap[asset.AssetId] = asset;
        }

        public void DeleteAsset(string id)
        {
            if (!assetMap.ContainsKey(id))
                return;

            Asset found = assetMap[id];
            assetList.Remove(found);
            assetMap.Remove(id);
        }

        public Asset FindAsset(string id)
        {
            if (assetMap.ContainsKey(id))
                return assetMap[id];

            return null;
        }

        public decimal CalculatePortfolioValue()
        {
            return assetList.Sum(item => item.GetCurrentWorth());
        }

        public List<Asset> GetAssetsByRiskLevel(string risk)
        {
            return assetList
                .Where(item => item is IRiskLevel level &&
                               level.GetRiskCategory().Equals(risk, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Asset> GetAllAssets()
        {
            return assetList;
        }

        public void ExecuteTrade(TradeEntry trade)
        {
            if (!assetMap.ContainsKey(trade.AssetId))
                throw new FinancialInputException("Instrument not found");

            Asset selected = assetMap[trade.AssetId];

            if (trade.ActionType.Equals("Buy", StringComparison.OrdinalIgnoreCase))
            {
                selected.Quantity += trade.Units;
            }
            else
            {
                if (selected.Quantity < trade.Units)
                    throw new FinancialInputException("Insufficient Units");

                selected.Quantity -= trade.Units;
            }
        }
    }

    class PortfolioPrinter
    {
        public void PrintConsoleSummary(AssetPortfolio portfolio)
        {
            List<Asset> allAssets = portfolio.GetAllAssets();

            Console.WriteLine("===== PORTFOLIO SUMMARY =====");

            var groupedAssets = allAssets.GroupBy(item => item.GetType().Name);

            foreach (var group in groupedAssets)
            {
                decimal totalInvestment = group.Sum(item => item.PurchasePrice * item.Quantity);
                decimal presentValue = group.Sum(item => item.GetCurrentWorth());

                Console.WriteLine($"Instrument Type: {group.Key}");
                Console.WriteLine($"Total Investment: {totalInvestment:C}");
                Console.WriteLine($"Current Value: {presentValue:C}");
                Console.WriteLine($"Profit/Loss: {(presentValue - totalInvestment):C}");
                Console.WriteLine();
            }

            Console.WriteLine($"Overall Portfolio Value: {portfolio.CalculatePortfolioValue():C}");

            var riskSummary = allAssets
                .OfType<IRiskLevel>()
                .GroupBy(item => item.GetRiskCategory())
                .Select(group => new { Risk = group.Key, Count = group.Count() });

            Console.WriteLine("Risk Distribution:");
            foreach (var item in riskSummary)
            {
                Console.WriteLine($"{item.Risk}: {item.Count}");
            }
        }

        public void PrintFileSummary(AssetPortfolio portfolio)
        {
            string fileName = $"PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

            using StreamWriter sw = new StreamWriter(fileName);

            sw.WriteLine("===== PORTFOLIO REPORT =====");
            sw.WriteLine($"Generated: {DateTime.Now}");
            sw.WriteLine();

            foreach (Asset asset in portfolio.GetAllAssets())
            {
                if (asset is IPrintable printable)
                {
                    sw.WriteLine(printable.GetReportText());
                }
            }

            sw.WriteLine();
            sw.WriteLine($"Total Portfolio Value: {portfolio.CalculatePortfolioValue():C}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            AssetPortfolio portfolio = new AssetPortfolio();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            StockAsset stock = new StockAsset
            {
                AssetId = "EQ001",
                AssetName = "TCS",
                Currency = "INR",
                Quantity = 100,
                PurchasePrice = 1500,
                MarketPrice = 1650,
                BoughtOn = new DateOnly(2024, 1, 1)
            };

            BondAsset bond = new BondAsset
            {
                AssetId = "BD001",
                AssetName = "SafeBond",
                Currency = "INR",
                Quantity = 200,
                PurchasePrice = 1000,
                MarketPrice = 1100,
                BoughtOn = new DateOnly(2023, 5, 1)
            };

            FundAsset fund = new FundAsset
            {
                AssetId = "MF001",
                AssetName = "GrowthPlus",
                Currency = "INR",
                Quantity = 50,
                PurchasePrice = 2000,
                MarketPrice = 2300,
                BoughtOn = new DateOnly(2024, 3, 1)
            };

            DepositAsset deposit = new DepositAsset
            {
                AssetId = "FD001",
                AssetName = "SecureFD",
                Currency = "INR",
                Quantity = 10,
                PurchasePrice = 10000,
                MarketPrice = 10500,
                BoughtOn = new DateOnly(2022, 6, 1)
            };

            portfolio.AddAsset(stock);
            portfolio.AddAsset(bond);
            portfolio.AddAsset(fund);
            portfolio.AddAsset(deposit);

            TradeEntry[] trades =
            {
                new TradeEntry { TradeId = "T1", AssetId = "EQ001", ActionType = "Buy", Units = 10, TradeDate = new DateOnly(2025, 1, 1) },
                new TradeEntry { TradeId = "T2", AssetId = "BD001", ActionType = "Sell", Units = 20, TradeDate = new DateOnly(2025, 2, 1) }
            };

            List<TradeEntry> tradeHistory = trades.ToList();

            foreach (TradeEntry trade in tradeHistory)
            {
                portfolio.ExecuteTrade(trade);
            }

            PortfolioPrinter printer = new PortfolioPrinter();
            printer.PrintConsoleSummary(portfolio);
            printer.PrintFileSummary(portfolio);
        }
    }
}