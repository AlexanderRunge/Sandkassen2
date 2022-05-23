namespace Sandkassen2
{
    internal static class UI
    {
        private static string name;

        public static void Welcome() //Denne Fuction er startsiden, er vil kører når man starter consollen.
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("Velkommen!");
            Console.Write("Hvad hedder du?");
            name = Console.ReadLine();
            UdskrivNavn();
        }

        public static void People() //Udskriver dit navn, når knappen P bliver trykkede
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            List<string> people = ReadPeopleContens();
            Console.WriteLine(people);
            
            Console.WriteLine("Indtast fornavn på person: (efterlad blank hvis du vil annulere)" ?? "");
            string fornavn = Console.ReadLine() ?? "";
            if (fornavn != "")
            {
                Console.Write("Efternavn på personen: ");
                string efternavn = Console.ReadLine();
                Console.Write("Telefon nummer på personen: ");
                string telefon = Console.ReadLine();
                Console.Write("Addressen på personen: ");
                string addresse = Console.ReadLine();
                Console.Write("Mailen på personen: ");
                string mail = Console.ReadLine();

                string person = fornavn + ", " + efternavn + ", " + telefon + ", " + addresse + ", " + mail;
            }

        }

        public static void ShowSearch() //Går igennem tekst filen og udskriver det der matcher med søgningen, når der tastes S
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("Hvad vil du søge: ");
            string search = Console.ReadLine();
            Console.WriteLine($"Her er resultaterne for søgningen: {search}");
            List<string> items = ReadItemsContens();
            foreach (string str in items) //Udskriver alle elementer i items der indeholder det der er søgt på
            {
                if (str.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(str);
                }
            } 
        }

        public static void EditSearchResult()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            List<string> items = ReadItemsContens();
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(i + ":\t" + items[i]);
            }

            Console.Write("Hvilken position vil du ændre? ");
            string update = Console.ReadLine() ?? "";
            if (update != "");
            {
                int position;
                if (int.TryParse(update, out position))
                {
                    Console.WriteLine("Teksten er: " + items[position]);
                    Console.Write("Hvad vil du ændre teksten til? ");
                    string newText = Console.ReadLine() ?? "";
                    if (newText != "")
                    {
                        items[position] = newText;
                        items.Sort();
                        File.WriteAllText("items.txt", String.Join("\n", items));
                    }
                }
            }
        }

        public static void AddSearchResult()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            List<string> items = ReadItemsContens();
            foreach (string str in items)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("Hvad vil du tilføje til søge listen?");
            string addSearch = Console.ReadLine() ?? "";
            string[] addArray = addSearch.Split(",");
            string tempString;
            for (int i = 0; i < addArray.Length; i++)
            {
                tempString = addArray[i];
                tempString.Trim();
                addArray[i] = tempString;
            }
            if (addSearch != "")
            {
                
                if (!items.Contains(addSearch, StringComparer.OrdinalIgnoreCase))
                {
                    for (int i = 0; i < addArray.Length; i++)
                    {
                        items.Add(addArray[i]);
                    }
                    string array = string.Join(", ", addArray);
                    Console.WriteLine($"Resultarte, {array}, er tilføjet");
                }
                else
                {
                    Console.WriteLine("Det du vil tilføje findes allerede.");
                }
            }

            File.WriteAllText("items.txt", String.Join("\n", items));
        }

        public static void RemoveSearchResult()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            List<string> items = ReadItemsContens();
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
        }

        private static List<string> ReadItemsContens()
        {
            string[] text = File.ReadAllLines("items.txt");
            List<string> items = new List<string>(text);
            return items;
        }

        private static List<string> ReadPeopleContens()
        {
            string[] text = File.ReadAllLines("people.txt");
            List<string> people = new List<string>(text);
            return people;
        }

        public static void ShowMenu()
        {
            Console.WriteLine("");
            Console.Write("Tast [X] for at lukke programet, [S] for at søge, [R] for at slette et søge resultat, [E] for at redigere et søge resultat, " +
                "[T] for at tilføje et søge resultat, [P] for at se din profil, [N] for at ændre dit navn");
        }

        private static void UdskrivNavn()
        {
            Console.WriteLine($"Du hedder: {name}");
        }
        
    }
}
