using System;

namespace uzd10
{
    class Program
    {
        static void Main(string[] args)
        {
            // A

            int first = 2;
            string second = "4";
            int result = first + int.Parse(second);
            Console.WriteLine(result);

            // B

            double x = 47.62;
            string y = "951";
            string z = "61X!";

            int x2 = (int?)x ?? 0;

            int tempY;
            int y2 = int.TryParse(y, out tempY) ? tempY : 0;

            int tempZ;
            int z2 = int.TryParse(z, out tempZ) ? tempZ : 0;

            Console.WriteLine(x2);
            Console.WriteLine(y2);
            Console.WriteLine(z2);
        }
    }
}
