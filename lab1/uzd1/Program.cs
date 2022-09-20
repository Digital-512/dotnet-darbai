using System;
using System.Text;

namespace uzd1
{
    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            string tekstas = "Aš jau žinau pagrindinius programų sudarymo principus!";

            // Išvedimas
            // 1 būdas
            Console.WriteLine($"Tekstas „{tekstas}”, sudarytas iš {tekstas.Length} simbolio(-ų).");

            // 2 būdas
            Console.WriteLine("Tekstas „" + tekstas + "”, sudarytas iš " + tekstas.Length + " simbolio(-ų).");

            // 3 būdas
            string isvedimas = string.Format("Tekstas „{0}”, sudarytas iš {1} simbolio(-ų).", tekstas, tekstas.Length);
            Console.WriteLine(isvedimas);
        }
    }
}
