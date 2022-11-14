using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace uzd1
{
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
            string fileName = "ProductsPriceHistory.json";
            string jsonString = File.ReadAllText(fileName);
            List<ProductPriceHistory> productPriceHistory = JsonSerializer.Deserialize<List<ProductPriceHistory>>(jsonString)!;

            // A)

            // Užklausa, kuri grąžina visus objekto duomenis (lambda)
            var priceHistory1 = productPriceHistory.Select(t => t).ToList();

            // Užklausa, kuri grąžina visus objekto duomenis (query)
            var priceHistory2 = (from p in productPriceHistory select p).ToList();

            // B)

            // Užklausa, kuri grąžina specifinius stulpelius (lambda)
            var listPrices1 = productPriceHistory.Select(t => new { t.ProductID, t.ListPrice }).ToList();

            // Užklausa, kuri grąžina specifinius stulpelius (query)
            var listPrices2 = (from p in productPriceHistory select new { p.ProductID, p.ListPrice }).ToList();

            // Išvedimas (testavimui)

            /*

            foreach (var item in priceHistory1)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} | {4} |", item.ProductID, item.StartDate, item.EndDate, item.ListPrice, item.ModifiedDate));
            }

            Console.ReadKey();

            foreach (var item in priceHistory2)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} | {4} |", item.ProductID, item.StartDate, item.EndDate, item.ListPrice, item.ModifiedDate));
            }

            Console.ReadKey();

            foreach (var item in listPrices1)
            {
                Console.WriteLine(string.Format("| {0} | {1} |", item.ProductID, item.ListPrice));
            }

            Console.ReadKey();

            foreach (var item in listPrices2)
            {
                Console.WriteLine(string.Format("| {0} | {1} |", item.ProductID, item.ListPrice));
            }

            */
        }
    }
}
