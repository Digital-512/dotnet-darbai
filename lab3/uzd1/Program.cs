using System;
using System.Text;

namespace uzd1
{
    class Author
    {
        private string Name;
        private string Email;
        private char Gender;

        public Author(string Name, string Email, char Gender)
        {
            this.Name = Name;
            this.Email = Email;
            this.Gender = Gender;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetEmail()
        {
            return Email;
        }

        public void SetEmail(string Email)
        {
            this.Email = Email;
        }

        public char GetGender()
        {
            return Gender;
        }

        public override string ToString()
        {
            return $"{Name} ({Gender}) at {Email}";
        }
    }

    class Book
    {
        private string Name;
        private Author Author;
        private double Price;
        private int Qty;

        public Book(string Name, Author Author, double Price, int Qty)
        {
            this.Name = Name;
            this.Author = Author;
            this.Price = Price;
            this.Qty = Qty;
        }

        public string GetName()
        {
            return Name;
        }

        public Author GetAuthor()
        {
            return Author;
        }

        public double GetPrice()
        {
            return Price;
        }

        public void SetPrice(double Price)
        {
            this.Price = Price;
        }

        public int GetQty()
        {
            return Qty;
        }

        public void SetQty(int Qty)
        {
            this.Qty = Qty;
        }

        public override string ToString()
        {
            return $"'{Name}' by {Author.ToString()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            // Testavimas
            Author autorius1 = new Author("Petras", "klevaitis@mail.com", 'm');
            Author autorius2 = new Author("Liepa", "liepaite@mail.com", 'f');

            // Autorių išvedimas į konsolę naudojant ToString().
            Console.WriteLine(autorius1.ToString());
            Console.WriteLine(autorius2.ToString());

            // Knygų sukūrimas.
            Book knyga1 = new Book("Lapai rudenį krenta", autorius1, 34.99, 100);
            Book knyga2 = new Book("C# programavimo pradmenys", autorius2, 28.74, 407);

            // Rezultatų išvedimas į konsolę.
            Console.WriteLine(knyga1.ToString());
            Console.WriteLine(knyga2.ToString());
        }
    }
}
