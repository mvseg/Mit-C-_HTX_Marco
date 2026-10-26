/****************************************************************/
/*   Program navn:              Pong                            */
/*   Programbeskrivelse:        Programmet spiller Tennis/Pong  */
/*                                                              */
/*    Forfatter:                Marco Saldo                     */
/*                                                              */
/****************************************************************/
Console.SetCursorPosition(0, 0);
string navn;
bool runGame;
int score = 0;
ConsoleKey prompt;
ConsoleKey tast;
int batY = 10;
const int batHøjde = 3;

Console.BackgroundColor = ConsoleColor.Red;/*Denne linje farver highlightteksten rød*/
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine("Hej, og velkommen til den bedste oplevelse af tennis du nogensinde kommer til at have :O");
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("\n");
/*Denne linje farver teksten rød*/ Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Dette er ikke en stor bedrift, da tennis ikke er en særlig sjov sport");
Console.WriteLine("Alligevel kommer din oplevelse af spillet, til at være interessant");
Console.WriteLine("Skriv dit navn:");
navn = Console.ReadLine();
Console.WriteLine("Navn registreret... Hej " + navn);
Console.WriteLine("Vil du starte spillet? (y/n)");

do
{
    prompt = Console.ReadKey(true).Key;
} while (prompt != ConsoleKey.Y && prompt != ConsoleKey.N);

runGame = prompt == ConsoleKey.Y;

if (runGame == true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
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
    do
    {
        tast = Console.ReadKey(true).Key;
        switch (tast)
        {
            case ConsoleKey.DownArrow:
                if (batY < 26-batHøjde) { batY++; }
                ;
                break;
            case ConsoleKey.UpArrow:
                if (batY > 3) { batY--; }
                break;
            case ConsoleKey.Escape:
                runGame = false;
                break;
        }
        for (int i = 0; i < batHøjde; i++)
        {
            Console.SetCursorPosition(13, batY + i);
            Console.Write("█");
        }
        if (batY < 23)
        {
            Console.SetCursorPosition(13, batY + batHøjde);
            Console.Write(" ");
        }
        if (batY == 25-batHøjde)
        {
            Console.SetCursorPosition(13, 25);
            Console.Write("_");
        }
        if (batY > 3)
        {
            Console.SetCursorPosition(13, batY - 1);
            Console.Write(" ");
        }
        Console.SetCursorPosition(111, 27);
        Console.WriteLine(batY);
    } while (runGame == true);
}
if (runGame == false)
{
    Console.Clear();
}
