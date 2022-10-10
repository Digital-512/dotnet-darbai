using System;

namespace uzd1_a
{
    class Program
    {
        // Metodas, priimantis sveikuosius skaičius
        static int PowerOfTwo(int num)
        {
            return num * num;
        }

        // Metodas, priimantis realiuosius skaičius
        static double PowerOfTwo(double num)
        {
            return num * num;
        }

        static void Main(string[] args)
        {
            int a = 7;
            double b = 7.5;

            int powA = PowerOfTwo(a);
            double powB = PowerOfTwo(b);

            Console.WriteLine($"A: {powA}, B: {powB}");
        }
    }
}
