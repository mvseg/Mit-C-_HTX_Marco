int batY = 10;
ConsoleKey tast;
int batHøjde = 3;
bool runGame;
ConsoleKey prompt;

do
{
prompt = Console.ReadKey(true).Key;
} while (prompt != ConsoleKey.Y && prompt != ConsoleKey.N);

runGame = prompt == ConsoleKey.Y;

if (runGame == true)
{
    Console.Clear();
}
if (runGame == true)
{
    for (int i = 3; i < 100; i++)
    {
        Console.SetCursorPosition(9 + i, 2);
        Console.Write("_");
        Console.SetCursorPosition(9 + i, 25);
        Console.Write("_");
    }
    for (int i = 0; i < 25; i++)
    {
        Console.SetCursorPosition(10, 2 + i);
        Console.Write("|");
        Console.SetCursorPosition(109, 2 + i);
        Console.Write("|");
    }
    for (int i = 0; i < batHøjde; i++)
    {
        Console.SetCursorPosition(13, batY + i);
        Console.Write("█");
    }
    if (batY < 20 + batHøjde)
    {
        Console.SetCursorPosition(13, batY + batHøjde);
        Console.Write(" ");
    }
    if (batY > 3)
    {
        Console.SetCursorPosition(13, batY - 1);
        Console.Write(" ");
    }
    Console.SetCursorPosition(111, 27);
    Console.WriteLine(batY);
    do
    {
        tast = Console.ReadKey(true).Key;
        switch (tast)
        {
            case ConsoleKey.DownArrow:
                if(batY < 23){ batY++; }
                ;
                break;
            case ConsoleKey.UpArrow:
                if (batY > 3) { batY--; }
                break;
            case ConsoleKey.Escape:
                runGame = false;
                break;
        }
        
    } while (runGame == true);
}
if (runGame == false)
{
    Console.Clear();
}

