using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandkassen2
{
    internal static class UI
    {
        private static string name;

        public static void Welcome()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("Velkommen!");
            Console.Write("Hvad hedder du?");
            name = Console.ReadLine();
            UdskrivNavn();
            ShowMenu();
        }
        public static void ChangeName()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("Hvad vil du hedde?");
            name = Console.ReadLine();
            UdskrivNavn();
            ShowMenu();
        }

        public static void Profile()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            UdskrivNavn();
            ShowMenu();
        }

        public static void ShowSearch()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("Hvad vil du søge: ");
            string search = Console.ReadLine();
            Console.WriteLine($"Her er resultaterne for søgningen: {search}");
            List<string> items = ReadFileContens();
            foreach (string str in items)
            {
                if (str.Contains(search))
                {
                    Console.WriteLine(str);
                }
            } 
            ShowMenu();
        }

        public static void AddSearchResult()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            List<string> items = ReadFileContens();
            foreach (string str in items)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("Hvad vil du tilføje til søge listen?");
            string addSearch = Console.ReadLine() ?? "";
            if (addSearch != "")
            {
                if (!items.Contains(addSearch, StringComparer.OrdinalIgnoreCase))
                {
                    items.Add(addSearch);
                    Console.WriteLine($"Resultartet er tilføjet");
                }
                else
                {
                    Console.WriteLine("Det du vil tilføje findes allerede.");
                }
            }
                
            File.WriteAllText("items.txt", String.Join("\n", items));
            ShowMenu();
        }

        public static void RemoveSearchResult()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            List<string> items = ReadFileContens();
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(i + ": \t" + items[i]);
            }
            Console.WriteLine("Hvilken position har tingen du vil slette?");
            string removeSearch = Console.ReadLine() ?? "";
            int position;
            if (removeSearch != "")
            {
                bool success = int.TryParse(removeSearch, out position);
                if (success)
                {
                    Console.WriteLine($"{items[position]} er nu slettet.");
                    items.Remove(items[position]);
                }
                else
                {
                    Console.WriteLine("Du indstatte ikke en gyldig position.");
                }
            }
            
            File.WriteAllText("items.txt", String.Join("\n", items));
            ShowMenu();
        }

        private static List<string> ReadFileContens()
        {
            string[] text = File.ReadAllLines("items.txt");
            List<string> items = new List<string>(text);
            return items;
        }

        public static void ShowMenu()
        {
            Console.WriteLine("");
            Console.Write("Tast [X] for at lukke programet, [S] for at søge, [T] for at tilføje et søge resultat, [P] for at se din profil, [N] for at ændre dit navn");
        }

        private static void UdskrivNavn()
        {
            Console.WriteLine($"Du hedder: {name}");
        }
        
    }
}
