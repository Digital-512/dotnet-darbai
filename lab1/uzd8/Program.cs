using System;
using System.Text;

namespace uzd8
{
    class Program
    {
        // Metodas patikrinimui, ar yra skaičius 3.
        static bool Patikrinti(int skaicius)
        {
            do
            {
                if (skaicius % 10 == 3) return true;
                skaicius /= 10;
            } while (skaicius != 0);

            return false;
        }

        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            // Suformuoti visą daugybos lentelę
            // nuo 1 iki 9 (nuo 1x1 iki 9x9).
            int i = 1, j = 1;

            do
            {
                do
                {
                    int sandauga = i * j;
                    bool yraTrys = Patikrinti(sandauga);
                    Console.WriteLine($"{i} x {j} = {sandauga} -> {yraTrys}");
                    j++;
                } while (j <= 9);
                i++;
                j = 1;
            } while (i <= 9);
        }
    }
}
