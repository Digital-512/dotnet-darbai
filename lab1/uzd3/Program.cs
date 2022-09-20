using System;
using System.Text;

namespace uzd3
{
    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Įrašykite 4 skaičius...");

            // Skaičių a, b, c, d įvedimas.
            Console.Write("a = ");
            short a = short.Parse(Console.ReadLine());
            Console.Write("b = ");
            short b = short.Parse(Console.ReadLine());
            Console.Write("c = ");
            short c = short.Parse(Console.ReadLine());
            Console.Write("d = ");
            short d = short.Parse(Console.ReadLine());

            // Surasti didžiausią skaičių.
            short max = Math.Max(Math.Max(Math.Max(a, b), c), d);

            // Surasti didžiausio skaičiaus kintamojo pavadinimą.
            string pavadinimas = max == a ? "a" : max == b ? "b" : max == c ? "c" : max == d ? "d" : "";

            // Išvedimas
            Console.WriteLine($"Didžiausias skaičius yra {pavadinimas}, kurio reikšmė yra {max}.");
        }
    }
}
