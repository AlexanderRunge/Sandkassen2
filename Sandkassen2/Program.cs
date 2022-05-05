using Sandkassen2;

bool test = false;

UI.ShowMenu();
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
    if (keyInfo.Key == ConsoleKey.N)
    {
        UI.Welcome();
    }
    if (keyInfo.Key == ConsoleKey.M)
    {
        UI.ShowMenu();
    }
} while (test == false);