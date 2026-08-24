/****************************************************************/
/*   Program navn:              Pong                            */
/*   Programbeskrivelse:        Programmet spiller Tennis/Pong  */
/*                                                              */
/*    Forfatter:                Marco Saldo                     */
/*                                                              */
/****************************************************************/
using System.ComponentModel.Design;

Console.SetCursorPosition(0, 0);
string navn;
bool runGame = false;
string yesNoRun;
int score = 0;
System.ConsoleKey tast;
/*Denne linje farver teksten rød*/
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Hej, og velkommen til den bedste oplevelse af tennis du nogensinde kommer til at have :O");
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine(" ");
Console.BackgroundColor = ConsoleColor.Red;/*Denne linje farver highlightteksten rød*/
Console.WriteLine("Dette er ikke en stor bedrift, da tennis ikke er en særlig sjov sport");
Console.WriteLine("Alligevel kommer din oplevelse af spillet, til at være interessant");
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine("Skriv dit navn:");
navn = Console.ReadLine();
Console.WriteLine("Navn registreret... Hej " + navn);

ConsoleKey response;

    Console.WriteLine("Vil du starte spillet? (y/n)");
do
{
    response = Console.ReadKey(true).Key;

} while (response != ConsoleKey.Y && response != ConsoleKey.N);

runGame = response == ConsoleKey.Y;

Console.WriteLine(runGame);
