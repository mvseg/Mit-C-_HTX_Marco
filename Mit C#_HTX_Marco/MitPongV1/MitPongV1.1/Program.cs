/****************************************************************/
/*   Program navn:              Pong                            */
/*   Programbeskrivelse:        Programmet spiller Tennis/Pong  */
/*                                                              */
/*    Forfatter:                Marco Saldo                     */
/*                                                              */
/****************************************************************/
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

Console.SetCursorPosition(0, 0);
string navn;
bool runGame;
int score = 0;
ConsoleKey prompt;
ConsoleKey tast;
int batY = 10;
int batHøjde = 4;
char boldTegn = 'O';
int hastighedY = 1;
int hastighedX = 1;
int boldX = 50;
int boldY = 10;
int laneY = 2;
int laneDY = 25;
int laneX = 10;
int laneDX = 109;
int batX = 20;
int spilHastighed = 100;
TimeSpan BallMoveDeltaTime = TimeSpan.FromMilliseconds(spilHastighed);
TimeSpan BallNextMoveTime;
Stopwatch BallMoveTimer;

bool hitTopWall()
{ 
    if (boldY==laneY+1)
    { 
        return true; 
    }
    return false;
}
bool hitBottomWall()
{
    if (boldY == laneDY - 1)
    {
        return true;
    }
    return false;
}
bool hitRightWall()
{
    if (boldX == laneDX - 1)
    {
        return true;
    }
    return false;
}
bool hitBat()
{
    if (((boldX == batX+1) && hastighedX == -1) && boldY >= batY && boldY <= batY + batHøjde - 1)
    {
        return true;
    }
    return false;
}
bool hitLeftWall()
{
    if (boldX == laneX+1 || boldX == laneX+2)
    {
        return true;
    }
    return false;
}
void gameOver()
{
    runGame = false;
    Console.Clear();
    Console.WriteLine($"Nå, {navn} det gik vist ikke så godt. Bedre held næste gang :) Din score var {score}");
    Console.WriteLine("Tryk på en tast for at lukke spillet");
    Console.ForegroundColor = ConsoleColor.Black;
}
void boldRemove(int x, int y)
{
    Console.SetCursorPosition(x, y);
    Console.Write(" ");
}
void boldDraw(int x, int y)
{
    Console.SetCursorPosition(x, y);
    Console.Write(boldTegn);
}
void stop()
{
    Console.Clear();
    runGame = false;
}
void boldUpdate()
{
    if (hitTopWall() || hitBottomWall())
    {
        boldRemove(boldX, boldY);
        hastighedY = -hastighedY;
        boldX += hastighedX;
        boldY += hastighedY;
        boldDraw(boldX, boldY);
    }
    else if (hitRightWall())
    {
        boldRemove(boldX, boldY);
        hastighedX = -hastighedX;
        boldX += hastighedX;
        boldY += hastighedY;
        boldDraw(boldX, boldY);
    }
    else if (hitBat())
    {
        boldRemove(boldX, boldY);
        hastighedX = -hastighedX;
        boldX += hastighedX;
        boldY += hastighedY;
        boldDraw(boldX, boldY);
        score += 1;
    }
    else if (hitLeftWall())
    {
        gameOver();
    }
    else
    {
        boldRemove(boldX, boldY);
        boldX += hastighedX;
        boldY += hastighedY;
        boldDraw(boldX, boldY);
    }
}

Console.CursorVisible = false;
    Console.BackgroundColor = ConsoleColor.Red;/*Denne linje farver highlightteksten rød*/
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("Hej, og velkommen til den bedste oplevelse af tennis du nogensinde kommer til at have :O");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine("\n");
    /*Denne linje farver teksten rød*/
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Dette er ikke en stor bedrift, da tennis ikke er en særlig sjov sport");
    Console.WriteLine("Alligevel kommer din oplevelse af spillet, til at være interessant");
    Console.Write("Skriv dit navn:");
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
    for (int i = 1; i < 100; i++)
    {
        Console.SetCursorPosition(laneX + i, laneY);
        Console.Write("─");
        Console.SetCursorPosition(laneX + i, laneDY);
        Console.Write("─");
    }
    Console.SetCursorPosition(laneX, laneY);
    Console.Write("┌");
    Console.SetCursorPosition(laneDX, laneY);
    Console.Write("┐");
    for (int i = 1; i < 23; i++)
    {
        Console.SetCursorPosition(laneX, laneY + i);
        Console.Write("│");
        Console.SetCursorPosition(laneDX, laneY + i);
        Console.Write("│");
    }
    Console.SetCursorPosition(laneX,laneDY);
    Console.Write("└");
    Console.SetCursorPosition(laneDX, laneDY);
    Console.Write("┘");
   
    do
    {

        BallNextMoveTime = BallMoveDeltaTime;
        BallMoveTimer = Stopwatch.StartNew();
        while (runGame == true)
        {
            if (BallMoveTimer.Elapsed >= BallNextMoveTime)
            {
                BallNextMoveTime = BallMoveTimer.Elapsed + BallMoveDeltaTime;
                boldUpdate();
            }

            BallMoveDeltaTime = TimeSpan.FromMilliseconds(spilHastighed);

            for (int i = 0; i < batHøjde; i++)
            {
                Console.SetCursorPosition(batX, batY + i);
                Console.Write("█");
            }
            if (batY < laneDY - 2)
            {
                Console.SetCursorPosition(batX, batY + batHøjde);
                Console.Write(" ");
            }
            if (batY == laneDY - batHøjde)
            {
                Console.SetCursorPosition(batX, laneDY);
                Console.Write("─");
            }
            if (batY > laneY + 1)
            {
                Console.SetCursorPosition(batX, batY - 1);
                Console.Write(" ");
            }
            Console.SetCursorPosition(111, 27);
            Console.WriteLine(score);
            Console.WriteLine(spilHastighed);

            Console.SetCursorPosition(boldX, boldY);
            Console.WriteLine(boldTegn);

            if (Console.KeyAvailable)
            {
                tast = Console.ReadKey(true).Key;

            
                switch (tast)
                {
                    case ConsoleKey.DownArrow:
                        if (batY < laneDY - batHøjde) { batY++; }
                        ;
                        break;
                    case ConsoleKey.UpArrow:
                        if (batY > laneY + 1) { batY--; }
                        break;
                    case ConsoleKey.Escape:
                        stop();
                        break;
                    case ConsoleKey.RightArrow:
                        spilHastighed -= 10;
                        break;
                    case ConsoleKey.LeftArrow:
                        spilHastighed += 10;
                        break;
                    case ConsoleKey.Backspace:
                        gameOver();
                        break;
                }
            }
        }
  
    } while (runGame == true);
}