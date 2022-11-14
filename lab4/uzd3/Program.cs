using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace uzd3
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

    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Products.json";
            string jsonString = File.ReadAllText(fileName);
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(jsonString)!;

            // E)

            // Užklausa, su požymiais ir rūšiavimu nuo A – Z pagal Name (lambda)
            var products1 = products.OrderBy(t => t.Name).Select(t => new { t.ProductID, t.Name, t.ProductNumber, t.Color, t.StandardCost, t.ListPrice }).ToList();

            // Užklausa, su požymiais ir rūšiavimu nuo A – Z pagal Name (query)
            var products2 = (from p in products orderby p.Name ascending select new { p.ProductID, p.Name, p.ProductNumber, p.Color, p.StandardCost, p.ListPrice }).ToList();

            // F)

            // Užklausa su požymiais ir rūšiavimu nuo Z iki A pagal StandardCost, o Name stulpelio pavadinimą pakeisti į ProductName (lambda)
            var products3 = products.OrderByDescending(t => t.StandardCost).Select(t => new { ProductName = t.Name, t.ProductNumber, t.Color, t.StandardCost }).ToList();

            // Užklausa su požymiais ir rūšiavimu nuo Z iki A pagal StandardCost, o Name stulpelio pavadinimą pakeisti į ProductName (query)
            var products4 = (from p in products orderby p.StandardCost descending select new { ProductName = p.Name, p.ProductNumber, p.Color, p.StandardCost }).ToList();

            // Išvedimas (testavimui)

            /*
            
            foreach (var item in products1)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} | {4} | {5} |", item.ProductID, item.Name, item.ProductNumber, item.Color, item.StandardCost, item.ListPrice));
            }

            Console.ReadKey();

            foreach (var item in products2)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} | {4} | {5} |", item.ProductID, item.Name, item.ProductNumber, item.Color, item.StandardCost, item.ListPrice));
            }

            Console.ReadKey();

            foreach (var item in products3)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} |", item.ProductName, item.ProductNumber, item.Color, item.StandardCost));
            }

            Console.ReadKey();

            foreach (var item in products4)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} |", item.ProductName, item.ProductNumber, item.Color, item.StandardCost));
            }

            */
        }
    }
}
