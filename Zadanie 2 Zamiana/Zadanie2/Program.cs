using System.Text.RegularExpressions;

namespace Zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj nazwę pliku tekstowego (bez rozszerzenia .txt)");

            string? nazwaPliku = Console.ReadLine();
            string[] pliki = Directory.GetFiles("C:\\Users\\Admin\\Desktop", nazwaPliku + ".txt", SearchOption.AllDirectories);

            if (pliki.Length == 0)
            {
                Console.WriteLine("Plik " + nazwaPliku + ".txt nie istnieje lub nie posiada tekstu.");
            }
            else
            {
                // Console.WriteLine(pliki);
                Console.WriteLine("Znaleziono: " + Path.GetFullPath(nazwaPliku + ".txt"));

                string tekstPliku = File.ReadAllText(pliki[0]);

                string[] slowa = tekstPliku.Split(" ");
                int iloscSlow = slowa.Length;
                int slowaPraca = 0;

                Console.WriteLine("Ilość słów: " + iloscSlow);

                for (int index = 0; index < iloscSlow; index++)
                {
                    // Console.WriteLine(slowa[index].ToLower());
                    // Console.WriteLine(slowa[index].ToLower() == "praca");

                    if (slowa[index].ToLower() != "praca")
                    {
                        continue;
                    }
                    // Console.WriteLine(">> TAK");
                    // Console.WriteLine(slowa[index]);
                    var regex = new Regex(@"\bPraca\b", RegexOptions.Compiled);
                    tekstPliku = regex.Replace(tekstPliku, "job");
                    // tekstPliku = tekstPliku.Replace(slowa[index], "job");
                    slowaPraca++;
                }

                if (slowaPraca < 5)
                {
                    Console.WriteLine("Potrzebne jest pięć słów \'Praca'");
                }
                else
                {
                    string tytul = nazwaPliku + "_changed-" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    File.WriteAllText("C:\\Users\\Admin\\Desktop\\Rudnicki Praktyki 2023\\" + tytul, tekstPliku); // Zapisz plik
                    Console.WriteLine("Zapisano plik pod tytułem: " + tytul);
                }

                Console.WriteLine("Wcziśnij przycisk aby zakończyć program");
                Console.ReadKey();
            }
        }
    }
}