using System;
using System.IO;
using System.Text;

namespace uzd2
{
    struct Juosteles
    {
        public Juosteles(string spalva)
        {
            this.spalva = spalva;
            this.kiekis = 0;
        }

        public string spalva { get; }
        public int kiekis { get; set; }
    }

    enum Ivertinimas
    {
        Micro,
        Small,
        Medium,
        Large
    }

    class Program
    {
        const string ivestiesFailas = "colors.txt";
        const string isvestiesFailas = "flags.txt";

        static Juosteles[] kruveles = { new Juosteles("G"), new Juosteles("Z"), new Juosteles("R") };

        static void Nuskaitymas()
        {
            // Nuskaitymas iš failo.
            StreamReader failas = null;

            try
            {
                failas = new StreamReader(ivestiesFailas);

                int n = int.Parse(failas.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string[] duomenys = failas.ReadLine().Split(" ");
                    string spalva = duomenys[0];
                    int kiekis = int.Parse(duomenys[1]);

                    switch (spalva)
                    {
                        case "G":
                            kruveles[0].kiekis += kiekis;
                            break;
                        case "Z":
                            kruveles[1].kiekis += kiekis;
                            break;
                        case "R":
                            kruveles[2].kiekis += kiekis;
                            break;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Nėra failo: {ivestiesFailas}");
            }
            finally
            {
                failas.Close();
                failas.Dispose();
            }
        }

        static int Skaiciavimas()
        {
            // Surasti, kurios spalvos juostelių yra mažiausiai.
            int min = 0;
            for (int i = 0; i < kruveles.Length; i++)
            {
                if (kruveles[i].kiekis < kruveles[min].kiekis)
                {
                    min = i;
                }
            }

            // Juostelių reikia po 2, todėl dalinti iš 2.
            return kruveles[min].kiekis / 2;
        }

        static void Irasymas(int x)
        {
            Ivertinimas iv = x <= 2 ? Ivertinimas.Micro : x > 2 && x <= 5 ? Ivertinimas.Small : x > 5 && x <= 10 ? Ivertinimas.Medium : Ivertinimas.Large;

            // Patikrinti, ar failas egzistuoja.
            // Jeigu egzistuoja, jį ištrinti.
            if (File.Exists(isvestiesFailas))
            {
                File.Delete(isvestiesFailas);
            }

            // Įrašymas į failą.
            StreamWriter failas = null;

            try
            {
                failas = new StreamWriter(isvestiesFailas);

                failas.WriteLine($"{x} {iv.ToString()}");
                foreach (Juosteles kruvele in kruveles)
                {
                    int likutis = kruvele.kiekis - x * 2;
                    failas.WriteLine($"{kruvele.spalva} = {likutis}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Klaida įrašant į failą {isvestiesFailas}: {e.InnerException.Message}");
            }
            finally
            {
                failas.Close();
                failas.Dispose();
            }
        }

        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            Nuskaitymas();
            int suklijuota = Skaiciavimas();
            Irasymas(suklijuota);
        }
    }
}
