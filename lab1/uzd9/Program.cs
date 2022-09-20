using System;
using System.Collections.Generic;

namespace uzd9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Duoti masyvai
            int[] A = { 1, 2, 2, 2, 9, 7, 1, 10, 3 };
            int[] B = { 3, 9 };

            // Atsakymui panaudojamas sąrašas, kad būtų galima gražiai užrašyti išvestį.
            List<int> atsakymas = new List<int>();

            // Surūšiuoti masyvą didėjimo tvarka.
            Array.Sort(A);

            // Tikrinti pasikartojančias reikšmes
            for (int i = 0; i < A.Length; i++)
            {
                // Praleisti pasikartojančias reikšmes surūšiuotame masyve.
                while (i < A.Length - 1 && A[i] == A[i + 1]) i++;

                // Tikrinti, ar raikšmė A[i] nėra masyve B.
                // Jeigu nėra, indeksas bus lygus -1.
                if (Array.IndexOf(B, A[i]) == -1) atsakymas.Add(A[i]);
            }

            // Išvedimas
            Console.WriteLine($"Atsakymas = [{string.Join(", ", atsakymas)}]");
        }
    }
}
