using System;
using System.Linq;

namespace uzd3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Duotas masyvas.
            int[] masyvas = { 25, 4, 33, 87, 2, 99, 60, 19, 81, 45, 10, 19, 72 };

            // Apskaičiuoti elementų sumą.
            int suma = masyvas.Sum();

            // Apskaičiuoti elementų vidurkį.
            double vidurkis = masyvas.Average();

            // Rasti mažiausią skaičių ir jo poziciją.
            var (minSk, minIndeksas) = masyvas.Select((x, i) => (x, i)).Min();

            // Rasti didžiausią skaičių ir jo poziciją.
            var (maxSk, maxIndeksas) = masyvas.Select((x, i) => (x, i)).Max();

            // Surikiuoti masyvą nuo mažiausio iki didžiausio skaičiaus.
            Array.Sort(masyvas);

            // Visus rezultatus išvesti į konsolę.
            Console.WriteLine($"Suma = {suma}\nVidurkis = {vidurkis}\nMinSk = {minSk}, MinIndeksas = {minIndeksas}\nMaxSk = {maxSk}, MaxIndeksas = {maxIndeksas}");
            Console.WriteLine("Surikiuotas masyvas: { " + string.Join(", ", masyvas) + " }");
        }
    }
}
