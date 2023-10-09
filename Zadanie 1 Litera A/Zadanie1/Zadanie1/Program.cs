using System;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            string tekst = File.ReadAllText("C:\\test\\test_woj_rud.txt");
            char[] listaLiter = tekst.ToCharArray();
            int iloscLiteryA = 0;
            char szukanaLitera = 'a';

            for (int i = 0; i < listaLiter.Length; i++)
            {
                char litera = listaLiter[i];
                if (litera.ToString().ToLower() == szukanaLitera.ToString().ToLower())
                {
                    iloscLiteryA++;
                }
            }

            Console.WriteLine("W pliku 'C:\\test\\test_woj_rud.txt' litera '" + szukanaLitera + "' występuje *" + iloscLiteryA + "* raz(y)");
            Console.WriteLine("\nWciśnij przycisk aby zakończyć program");
            Console.ReadKey();
        }
    }
}