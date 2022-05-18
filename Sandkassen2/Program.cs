using Sandkassen2;

bool test = false;

UI.Welcome();
do
{
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
    if (keyInfo.Key == ConsoleKey.T)
    {
        UI.AddSearchResult();
    }
    if (keyInfo.Key == ConsoleKey.R)
    {
        UI.RemoveSearchResult();
    }
    if (keyInfo.Key == ConsoleKey.N)
    {
        UI.ChangeName();
    }
    if (keyInfo.Key == ConsoleKey.P)
    {
        UI.Profile();
    }
} while (test == false);