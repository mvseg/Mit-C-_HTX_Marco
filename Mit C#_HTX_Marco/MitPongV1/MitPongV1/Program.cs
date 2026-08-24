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
string yesNoRun;
int score = 0;
ConsoleKey tast;
Console.BackgroundColor = ConsoleColor.Red;/*Denne linje farver highlightteksten rød*/
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine("Hej, og velkommen til den bedste oplevelse af tennis du nogensinde kommer til at have :O");
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine(" ");
/*Denne linje farver teksten rød*/ Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Dette er ikke en stor bedrift, da tennis ikke er en særlig sjov sport");
Console.WriteLine("Alligevel kommer din oplevelse af spillet, til at være interessant");
Console.WriteLine("Skriv dit navn:");
navn = Console.ReadLine();
Console.WriteLine("Navn registreret... Hej " + navn);
Console.WriteLine("Vil du starte spillet? (y/n)");

do
{
    tast = Console.ReadKey(true).Key;
} while (tast != ConsoleKey.Y && tast != ConsoleKey.N);

runGame = tast == ConsoleKey.Y;

Console.WriteLine(runGame);