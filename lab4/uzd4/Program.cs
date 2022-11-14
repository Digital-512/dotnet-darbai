using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace uzd4
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public double StandardCost { get; set; }
        public double ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public double? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class ProductPriceHistory
    {
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double ListPrice { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string priceHistoryJson = File.ReadAllText("ProductsPriceHistory.json");
            List<ProductPriceHistory> productPriceHistory = JsonSerializer.Deserialize<List<ProductPriceHistory>>(priceHistoryJson)!;

            string productsJson = File.ReadAllText("Products.json");
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(productsJson)!;

            // G)

            // Užklausa, kuri grąžina (ProductPriceHistory) kiekvieną produktą ir didžiausią to produkto istorijos kainą bei kiek kainų pokyčių atlikta (lambda)
            var prices1 = productPriceHistory.GroupBy(t => t.ProductID).Select(g => new
            {
                ProductID = g.Key,
                MaxListPrice = g.Max(t => t.ListPrice),
                ModificationCount = g.Count()
            }).ToList();

            // Užklausa, kuri grąžina (ProductPriceHistory) kiekvieną produktą ir didžiausią to produkto istorijos kainą bei kiek kainų pokyčių atlikta (query)
            var prices2 = (from p in productPriceHistory
                           group p by p.ProductID into g
                           select new
                           {
                               ProductID = g.Key,
                               MaxListPrice = (from t in g select t.ListPrice).Max(),
                               ModificationCount = g.Count()
                           }).ToList();

            // H)

            // Užklausa, kuri grąžina (Product) sugrupuotus įrašus pagal Color ir SizeUnitMeasureCode bei paskaičiuoja
            // ListPrice sumą, vidurkį, mažiausią, didžiausią reikšmę, apjungia Color ir SizeUnitMeasureCode į vieną bendrą stulpelį,
            // filtracija pagal ProductNumber, įrašai, kurie prasideda „BK-“ simboliais (lambda)
            var products1 = products.Where(t => t.ProductNumber.StartsWith("BK-")).GroupBy(t => new { t.Color, t.SizeUnitMeasureCode }).Select(g => new
            {
                ColorWithSizeUnitMeasureCode = $"{g.Key.Color} ( {g.Key.SizeUnitMeasureCode})",
                SummaryListPrice = g.Sum(t => t.ListPrice),
                AverageListPrice = g.Average(t => t.ListPrice),
                MaxListPrice = g.Max(t => t.ListPrice),
                MinListPrice = g.Min(t => t.ListPrice)
            }).ToList();

            // Užklausa, kuri grąžina (Product) sugrupuotus įrašus pagal Color ir SizeUnitMeasureCode bei paskaičiuoja
            // ListPrice sumą, vidurkį, mažiausią, didžiausią reikšmę, apjungia Color ir SizeUnitMeasureCode į vieną bendrą stulpelį,
            // filtracija pagal ProductNumber, įrašai, kurie prasideda „BK-“ simboliais (query)
            var products2 = (from p in products
                             where p.ProductNumber.StartsWith("BK-")
                             group p by new { p.Color, p.SizeUnitMeasureCode } into g
                             select new
                             {
                                 ColorWithSizeUnitMeasureCode = $"{g.Key.Color} ( {g.Key.SizeUnitMeasureCode})",
                                 SummaryListPrice = (from t in g select t.ListPrice).Sum(),
                                 AverageListPrice = (from t in g select t.ListPrice).Average(),
                                 MaxListPrice = (from t in g select t.ListPrice).Max(),
                                 MinListPrice = (from t in g select t.ListPrice).Min(),
                             }).ToList();

            // Išvedimas (testavimui)

            /*

            foreach (var item in prices1)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} |", item.ProductID, item.MaxListPrice, item.ModificationCount));
            }

            Console.ReadKey();

            foreach (var item in prices2)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} |", item.ProductID, item.MaxListPrice, item.ModificationCount));
            }

            Console.ReadKey();

            foreach (var item in products1)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} | {4} |", item.ColorWithSizeUnitMeasureCode, item.SummaryListPrice, item.AverageListPrice, item.MaxListPrice, item.MinListPrice));
            }

            Console.ReadKey();

            foreach (var item in products2)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} | {4} |", item.ColorWithSizeUnitMeasureCode, item.SummaryListPrice, item.AverageListPrice, item.MaxListPrice, item.MinListPrice));
            }

            */
        }
    }
}
