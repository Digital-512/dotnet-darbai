using System;
using System.Text;

namespace uzd12
{
    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Įrašykite natūraliuosius skaičius n ir m (n <= m)...");

            int n, m;

            if (int.TryParse(Console.ReadLine(), out n) && int.TryParse(Console.ReadLine(), out m))
            {
                if (n <= m)
                {
                    int kiekis = 0;
                    int suma = 0;

                    for (int i = n; i <= m; i++)
                    {
                        kiekis++;
                        suma += i;
                    }

                    float vidurkis = (float)suma / kiekis;

                    Console.WriteLine($"n={n}, m={m} -> Suma: {suma}, Vidurkis: {vidurkis}");
                }
                else
                {
                    Console.WriteLine("Skaičius n negali būti didesnis už m.");
                }
            }
            else
            {
                Console.WriteLine("Įvesta klaidinga reikšmė.");
            }
        }
    }
}
