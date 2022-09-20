using System;
using System.Text;

namespace uzd5
{
    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            // Keturženklis skaičius.
            const int n = 1256;

            // Patikrinama, ar sandauga pirmojo ir paskutiniojo skaitmens yra didesnė nei
            // antrojo ir trečiojo skaitmenų suma.
            bool sandaugaDidesne = n / 1000 % 10 * n % 10 > n / 100 % 10 + n / 10 % 10;

            // Išvedimas.
            Console.WriteLine($"n = {n}");
            Console.WriteLine($"Pirmojo ir paskutinio skaitmens sandauga {(sandaugaDidesne ? "YRA" : "NĖRA")} didesnė nei antrojo ir trečiojo skaitmenų suma.");
        }
    }
}
