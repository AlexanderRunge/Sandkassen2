using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandkassen2
{
    internal static class UI
    {
        public static void Welcome()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("Når du er færdig, så tast [M] for at komme til menuen, eller tryk [X], for at forlade programmet");
            Console.WriteLine("Hvad hedder du?");
            string navn = Console.ReadLine();
            UdskrivNavn(navn);
        }

        public static void ShowSearch()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            bool test2 = false;

            Console.WriteLine("Når du er færdig, så tast [M] for at komme til menuen, eller tryk [X], for at forlade programmet");
            Console.WriteLine("Hvad vil du søge: ");
            string søg = Console.ReadLine();
            Console.WriteLine($"Her er resultaterne for søgningen: {søg}");
            søg = søg.ToLower();
            if (søg == "brød")
            {
                Console.WriteLine("Forskellige typer brød: \n" +
                                  "1.\t Rugbrød \n" +
                                  "2.\t Fransbrød \n" +
                                  "3.\t Surdejsbrød \n");
            }
            else
            {
                Console.WriteLine("Der var ingen resultater");
            }
        }

        public static void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Tast [M] for at komme til menu, [X] for at lukke programet, [S] for at søge, [N] for at give dit navn");
        }

        private static void UdskrivNavn(string navn)
        {
            Console.WriteLine($"Du hedder: {navn}");
        }
        
    }
}
