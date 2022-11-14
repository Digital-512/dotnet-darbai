using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace uzd5
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

            // I)

            // Užklausa, kuri apjungia ProductListPriceHistory ir Product (per ProductID) lenteles/sąrašus bei iš jų abiejų išrenka reikiamus duomenų atributus
            var productsInfo1 = products.Join(productPriceHistory, c => c.ProductID, o => o.ProductID, (c, o) => new
            {
                c.ProductID,
                c.Name,
                c.Size,
                c.Weight,
                o.StartDate,
                o.EndDate,
                o.ListPrice,
                o.ModifiedDate
            }).ToList();

            // Užklausa, kuri sudarytų sąrašą kiekvieno Product įrašo (ProductID, Name) ir to produkto
            // pirmąją ir paskutiniąją publikuotą istorijos kainą (StartDate – min ir max, gali reikėti kelių join‘ų).
            // Sąrašą sudaryti tik iš įrašų kai FirstPrice ir LastPrice skiriasi, pavyzdžiui – viso 77 įrašai
            var productsInfo2 = products.Select(p => new
            {
                p.ProductID,
                p.Name,
                FirstPrice = productPriceHistory.Where(t => t.ProductID == p.ProductID).Select(t => new { t.ListPrice, t.StartDate }).OrderBy(t => t.StartDate).FirstOrDefault()?.ListPrice,
                LastPrice = productPriceHistory.Where(t => t.ProductID == p.ProductID).Select(t => new { t.ListPrice, t.StartDate }).OrderByDescending(t => t.StartDate).FirstOrDefault()?.ListPrice
            }).Where(t => t.FirstPrice != t.LastPrice).ToList();

            // FirstPrice ir LastPrice su Join
            var productsInfo3 = products.Select(p => new
            {
                p.ProductID,
                p.Name,
                FirstPrice = productPriceHistory.Join(products, a => a.ProductID, b => p.ProductID, (a, b) => new { a.ListPrice, a.StartDate }).OrderBy(t => t.StartDate).FirstOrDefault()?.ListPrice,
                LastPrice = productPriceHistory.Join(products, a => a.ProductID, b => p.ProductID, (a, b) => new { a.ListPrice, a.StartDate }).OrderByDescending(t => t.StartDate).FirstOrDefault()?.ListPrice
            }).Where(t => t.FirstPrice != t.LastPrice).ToList();

            // Išvedimas (testavimui)

            /*

            foreach (var item in productsInfo1)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} |", item.ProductID, item.Name, item.Size, item.Weight, item.StartDate, item.EndDate, item.ListPrice, item.ModifiedDate));
            }

            Console.ReadKey();

            foreach (var item in productsInfo2)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} |", item.ProductID, item.Name, item.FirstPrice, item.LastPrice));
            }

            // Turi būti 77
            Console.WriteLine(productsInfo2.Count);

            Console.ReadKey();

            foreach (var item in productsInfo3)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} |", item.ProductID, item.Name, item.FirstPrice, item.LastPrice));
            }

            // Turi būti 77
            Console.WriteLine(productsInfo3.Count);

            */
        }
    }
}
