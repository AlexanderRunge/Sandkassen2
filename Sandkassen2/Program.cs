using Sandkassen2;

//File.WriteAllText("items.txt", "");
//File.WriteAllText("people.txt", "");
bool test = false;

do
{
    UI.ShowMenu();
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    if (keyInfo.Key == ConsoleKey.X)
    {
        test = true;
        return;
    }
    if (keyInfo.Key == ConsoleKey.S)
    {
        UI.ShowSearch();
    }
    if (keyInfo.Key == ConsoleKey.E)
    {
        UI.EditSearchResult();
    }
    if (keyInfo.Key == ConsoleKey.T)
    {
        UI.AddSearchResult();
    }
    if (keyInfo.Key == ConsoleKey.R)
    {
        UI.RemoveSearchResult();
    }
    if (keyInfo.Key == ConsoleKey.P)
    {
        UI.People();
    }
} while (test == false);