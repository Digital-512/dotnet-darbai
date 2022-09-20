using System;
using System.Text;

namespace uzd7
{
    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            // Įvedimas
            Console.WriteLine("Įveskite skaičių n...");
            int n = int.Parse(Console.ReadLine());
            int atitikmuo = 0;
            int liekana;

            Console.WriteLine($"Įvestis: {n}");

            // Nustatyti įvesto skaičiaus n ilgį.
            // Sukurti apsuktą skaičiaus n atitikmenį.
            int ilgis = 0;

            while (n > 0)
            {
                liekana = n % 10;
                atitikmuo = atitikmuo * 10 + liekana;
                n /= 10;
                ilgis++;
            }

            // Išvedimas
            Console.WriteLine($"Ilgis: {ilgis}");
            Console.WriteLine($"Atitikmuo: {atitikmuo}");
        }
    }
}
