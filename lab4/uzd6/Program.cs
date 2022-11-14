using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace uzd6
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

            // K)

            // Užklausa, kuri išrenka 2012 ir 2013 metais galiojusias pradžios (StartDate) kainas ir prekes.
            // Duomenys surūšiuojami pagal Name didėjimo tvarka. Prie istorinių duomenų prijungiamas Product sąrašas ir
            // paskaičiuojamas kiekvienos prekės kainų istorijos vidurkis.
            // Papildomai reikia praleisti 3 pirmus įrašus ir paimti tik sekančius 5 įrašus
            var productPrices = productPriceHistory.Where(t => t.StartDate.Year == 2012 || t.StartDate.Year == 2013).GroupBy(t => t.ProductID).Join(products, c => c.Key, o => o.ProductID, (c, o) => new
            {
                o.ProductID,
                o.Name,
                AverageListPrice = c.Average(t => t.ListPrice)
            }).OrderBy(t => t.Name).Skip(3).Take(5).ToList();

            // Papildomai atlikite šio sąrašo serializaciją, išsaugant duomenis į JSON'ą
            string newJson = JsonSerializer.Serialize(productPrices);

            // Išsaugoti JSON failą
            using (StreamWriter writer = new StreamWriter("NewJson.json"))
            {
                writer.Write(newJson);
            }

            // Išvedimas (testavimui)

            /*

            foreach (var item in productPrices)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} |", item.ProductID, item.Name, item.AverageListPrice));
            }

            */
        }
    }
}
