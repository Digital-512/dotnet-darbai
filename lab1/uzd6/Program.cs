using System;
using System.Text;

namespace uzd6
{
    class Program
    {
        // Metodas skaičiaus n faktorialui skaičiuoti.
        static ulong Fact(uint n)
        {
            ulong t = 1;

            for (uint i = 2; i <= n; i++)
            {
                t *= i;
            }

            return t;
        }

        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Įveskite teigiamą skaičių n...");

            uint n = uint.Parse(Console.ReadLine());
            ulong f = Fact(n);

            Console.WriteLine($"Skaičiaus {n} faktorialas yra: {f}");
        }
    }
}
