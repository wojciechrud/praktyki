using System;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string[] imiona = { "Ania", "Kasia", "Basia", "Zosia" };
            string[] nazwiska = { "Kowalska", "Nowak" };
            string seperator = ";";

            var nazwaPliku = "C:\\test\\users-" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm") + ".csv";
            string csvTekst = "Lp" + seperator + "Imie" + seperator + "Nazwisko" + seperator + "RokUrodzenia" + Environment.NewLine;

            File.WriteAllText(nazwaPliku, csvTekst);

            for (int i = 1; i < 101; i++)
            {
                string tekstDoDodania = i + seperator + imiona[random.Next(0, imiona.Length)] + seperator + nazwiska[random.Next(0, nazwiska.Length)] + seperator + random.Next(1990, 2000) + Environment.NewLine;
                File.AppendAllText(nazwaPliku, tekstDoDodania);
            }

            Console.WriteLine("Plik został zapisany.");
        }
    }
}