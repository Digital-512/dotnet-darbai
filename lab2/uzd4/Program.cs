using System;
using System.Text;
using System.Collections.Generic;

namespace uzd4
{
    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            // Duotas sąrašas.
            List<string> vardai = new List<string> { "Jake", "Jack", "Harry", "Jacob", "Charlie", "Thomas", "George", "Oscar", "James", "William" };

            // 1. Patikrinti, ar sukurtame sąraše egzistuoja „Harry“ vardas.
            bool egzHarry = vardai.Contains("Harry");
            Console.WriteLine("Vardas „Harry” " + (egzHarry ? "egzistuoja" : "neegzistuoja"));

            // 2. Rasti sąrašo 8-ojo indekso reikšmę.
            string reiksme8 = vardai[8];
            Console.WriteLine("8-ojo indekso reikšmė: " + reiksme8);

            // 3. Į sąrašą įterpti naują vardą „Bob“ į 4-tą poziciją.
            vardai.Insert(4, "Bob");
            Console.WriteLine("Sąrašas po įterpimo: " + string.Join(", ", vardai));

            // 4. Ištrinti sąrašo elementus, jei vardas prasideda iš „J“ raidės.
            vardai.RemoveAll(v => v.StartsWith("J"));
            Console.WriteLine("Sąrašas po ištrynimo: " + string.Join(", ", vardai));

            // 5. Išvesti likusio sąrašo elementų kiekį.
            Console.WriteLine("Liko elementų: " + vardai.Count);

            // 6. Rasti paskutiniojo sąrašo elemento reikšmę.
            string paskutine = vardai[vardai.Count - 1];
            Console.WriteLine("Paskutinė sąrašo reikšmė: " + paskutine);

            // 7. Į sąrašą įterpti naujas reikšmes: „Emily“, „Megan“, „Susan“, „Sarah“, „Margaret“.
            vardai.AddRange(new string[] { "Emily", "Megan", "Susan", "Sarah", "Margaret" });
            Console.WriteLine("Sąrašas po įterpimo: " + string.Join(", ", vardai));

            // 8. Surūšiuoti sąrašą nuo Z iki A.
            vardai.Sort((a, b) => b.CompareTo(a));
            Console.WriteLine("Sąrašas po surūšiavimo nuo Z iki A: " + string.Join(", ", vardai));

            // 9. Rasti sąrašo elementą „Thomas“ ir jį pakeisti į „Tom“.
            vardai[vardai.IndexOf("Thomas")] = "Tom";

            // 10. Išvesti turimo sąrašo reikšmes.
            Console.WriteLine("Išvesti sąrašą: " + string.Join(", ", vardai));
        }
    }
}
