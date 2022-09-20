using System;
using System.Text;

namespace uzd4
{
    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Įveskite mėnesio skaičių...");

            // Įvedimas
            int n;
            bool tinkamas = int.TryParse(Console.ReadLine(), out n);

            string isvedimas = "n => " + n + " => ";

            if (tinkamas)
            {
                switch (n)
                {
                    case 1:
                        isvedimas += "(sausis) => žiema";
                        break;
                    case 2:
                        isvedimas += "(vasaris) => žiema";
                        break;
                    case 3:
                        isvedimas += "(kovas) => pavasaris";
                        break;
                    case 4:
                        isvedimas += "(balandis) => pavasaris";
                        break;
                    case 5:
                        isvedimas += "(gegužė) => pavasaris";
                        break;
                    case 6:
                        isvedimas += "(birželis) => vasara";
                        break;
                    case 7:
                        isvedimas += "(liepa) => vasara";
                        break;
                    case 8:
                        isvedimas += "(rugpjūtis) => vasara";
                        break;
                    case 9:
                        isvedimas += "(rugsėjis) => ruduo";
                        break;
                    case 10:
                        isvedimas += "(spalis) => ruduo";
                        break;
                    case 11:
                        isvedimas += "(lapkritis) => ruduo";
                        break;
                    case 12:
                        isvedimas += "(gruodis) => žiema";
                        break;
                    default:
                        isvedimas += "Tokio mėnesio nėra.";
                        break;
                }

                Console.WriteLine(isvedimas);
            }
            else
            {
                Console.WriteLine("Įvesta klaidinga reikšmė.");
            }
        }
    }
}
