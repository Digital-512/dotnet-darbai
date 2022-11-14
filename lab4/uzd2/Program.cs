using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace uzd2
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

            // C)

            // Užklausa, kuri išrenka visus duomenis (ProductPriceHistory), produkto su ID 739 (lambda)
            var product1 = productPriceHistory.Where(t => t.ProductID == 739).ToList();

            // Užklausa, kuri išrenka visus duomenis (ProductPriceHistory), produkto su ID 739 (query)
            var product2 = (from p in productPriceHistory where p.ProductID == 739 select p).ToList();

            // D)

            // Užklausa, kuri išrenka aktyvias kainas (pateiktų stulpelių), kai EndDate nėra NULL (lambda)
            var prices1 = productPriceHistory.Where(t => t.EndDate != null).Select(t => new { t.ProductID, t.StartDate, t.EndDate, t.ListPrice }).ToList();

            // Užklausa, kuri išrenka aktyvias kainas (pateiktų stulpelių), kai EndDate nėra NULL (query)
            var prices2 = (from p in productPriceHistory where p.EndDate is not null select new { p.ProductID, p.StartDate, p.EndDate, p.ListPrice }).ToList();

            // Išvedimas (testavimui)

            /*

            foreach (var item in product1)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} | {4} |", item.ProductID, item.StartDate, item.EndDate, item.ListPrice, item.ModifiedDate));
            }

            Console.ReadKey();

            foreach (var item in product2)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} | {4} |", item.ProductID, item.StartDate, item.EndDate, item.ListPrice, item.ModifiedDate));
            }

            Console.ReadKey();

            foreach (var item in prices1)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} |", item.ProductID, item.StartDate, item.EndDate, item.ListPrice));
            }

            Console.ReadKey();

            foreach (var item in prices2)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} |", item.ProductID, item.StartDate, item.EndDate, item.ListPrice));
            }

            */
        }
    }
}
