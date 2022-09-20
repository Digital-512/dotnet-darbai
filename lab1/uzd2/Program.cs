using System;
using System.Text;

namespace uzd2
{
    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Įrašykite skaičių...");

            int skaicius;
            bool tinkamas = int.TryParse(Console.ReadLine(), out skaicius);

            Console.WriteLine(tinkamas
                ? $"Įvestas skaičius yra {(skaicius % 2 == 0 ? "lyginis" : "nelyginis")}."
                : "Įvesta klaidinga reikšmė.");
        }
    }
}
