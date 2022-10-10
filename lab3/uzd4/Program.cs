using System;
using System.Linq;
using System.Text;

namespace uzd4
{
    interface IView
    {
        string GetTitle();
        string GetPresentation();
    }

    class Shop : IView
    {
        private string Title;
        private Product[] Products;
        private Order[] Orders = { };

        public Shop(string Title, Product[] Products)
        {
            this.Title = Title;
            this.Products = Products;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetPresentation()
        {
            return $"Parduotuvė „{Title}” - čia mažiausios kainos!";
        }

        public Product[] GetInventory()
        {
            return Products;
        }

        public void BuyInventory(string CustomerName, string CustomerAddress, Product[] Products)
        {
            Order NewBuy = new Order(CustomerName, CustomerAddress, Products);
            Orders = Orders.Append(NewBuy).ToArray();

            Console.WriteLine("[Sukurtas užsakymas] -> " + NewBuy.ToString());
        }
    }

    class Product : IView
    {
        private string Title;
        private double Price;

        public Product(string Title, double Price)
        {
            this.Title = Title;
            this.Price = Price;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetPresentation()
        {
            return $"Produktas „{Title}”, Kaina: {Price}. Dabar nuolaidos!";
        }

        public double GetPrice()
        {
            return Price;
        }
    }

    class Order
    {
        private string CustomerName;
        private string CustomerAddress;
        private Product[] Products;

        public Order(string CustomerName, string CustomerAddress, Product[] Products)
        {
            this.CustomerName = CustomerName;
            this.CustomerAddress = CustomerAddress;
            this.Products = Products;
        }

        public override string ToString()
        {
            string ProductList = string.Join(", ", Products.Select(t => t.GetTitle()));
            double Sum = Products.Select(t => t.GetPrice()).Sum();
            return $"Vardas: {CustomerName}, Adresas: {CustomerAddress}, Prekės: {ProductList}, Suma: {Sum} eur.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            // Sukurti pavyzdinius objektus.

            Product[] Produktai = {
                new Product("Kompiuteris", 688.99),
                new Product("Televizorius", 375.99),
                new Product("Klaviatūra", 15.89),
                new Product("Wi-Fi maršrutizatorius", 28.79)
            };

            Shop Parduotuve = new Shop("InterShopp", Produktai);

            // Išvesti parduotuvės pavadinimą.
            Console.WriteLine(Parduotuve.GetTitle());

            Product[] Inventorius = Parduotuve.GetInventory();
            Console.WriteLine("Prekės: " + string.Join(", ", Inventorius.Select(t => t.GetTitle())));

            // Sukurti užsakymą.
            Product[] PerkamiProduktai = { Inventorius[0], Inventorius[2] };
            Parduotuve.BuyInventory("Antanas", "Bijūnų g. 17, Klaipėda", PerkamiProduktai);

            // Parduotuvės ir perkamo produkto prezentacijos.
            Console.WriteLine(Parduotuve.GetPresentation());
            Console.WriteLine(PerkamiProduktai[0].GetPresentation());
        }
    }
}
