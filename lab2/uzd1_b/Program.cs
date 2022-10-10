using System;

namespace uzd1_b
{
    class Program
    {
        private static float celsius = 17.5f;
        private static float fahrenheit;
        private static float kelvins;

        // Metodas, kuriame Celsijaus reikšmė konvertuojama į Farenheito ir Kelvino matavimo vienetus.
        static void TemperatureConversions(out float f, out float k, float c = 30)
        {
            try
            {
                f = (c * 9) / 5 + 32;
                k = c + 273.15f;
            }
            catch (Exception e)
            {
                f = k = 0;
                Console.WriteLine($"Klaida: {e}");
            }
        }

        static void Main(string[] args)
        {
            TemperatureConversions(out fahrenheit, out kelvins); // Nepriskirta Celsijaus reikšmė.
            Console.WriteLine($"fahrenheit = {fahrenheit}, kelvins = {kelvins}");

            TemperatureConversions(out fahrenheit, out kelvins, celsius); // Priskirta Celsijaus reikšmė 17.5.
            Console.WriteLine($"celsius = {celsius}, fahrenheit = {fahrenheit}, kelvins = {kelvins}");
        }
    }
}
