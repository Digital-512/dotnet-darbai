using System;
using System.Text;

namespace uzd11
{
    class Program
    {
        // Metodas skaičiaus simetrijai patikrinti.
        static bool IsSymmetrical(int n)
        {
            int temp = n;
            int rev = 0;

            while (temp > 0)
            {
                rev = rev * 10 + temp % 10;
                temp /= 10;
            }

            return rev == n;
        }

        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Įveskite skaičių...");

            int n = int.Parse(Console.ReadLine());
            bool sym = IsSymmetrical(n);

            Console.WriteLine($"IsSymmetrical({n}) -> {sym}");
        }
    }
}
