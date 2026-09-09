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
string navn1;
string navn2;
bool runGame;
int score1 = 0;
int score2 = 0;
ConsoleKey prompt;
ConsoleKey tast;
int batY = 17;
int batHøjde = 4;
char boldTegn = 'O';
int hastighedY;
int hastighedX;
int boldX;
int boldY;
int laneY = 10;
int laneDY = 33;
int laneX = 10;
int laneDX = 109;
int batX = 20;
int spilHastighed = 100;
TimeSpan BallMoveDeltaTime = TimeSpan.FromMilliseconds(spilHastighed);
TimeSpan BallNextMoveTime;
Stopwatch BallMoveTimer;
int bat2Y = 17;
int bat2Højde = 4;
int bat2X = 99;
var rand = new Random();

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
    if (boldX == laneDX - 1 || boldX == laneDX - 2)
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
bool hitBat2()
{
    if (((boldX == bat2X - 1) && hastighedX == 1) && boldY >= bat2Y && boldY <= bat2Y + batHøjde - 1)
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
void gameOver1()
{
    runGame = false;
    Console.Clear();
    Console.WriteLine($"Tillykke, {navn1} det gik da godt. Tillykke med de 20 point.");
    Console.WriteLine($"{navn2}, Bedre held næste gang :) Din score var {score2}");
    Console.WriteLine("Tryk på en tast for at lukke spillet");
    Console.ForegroundColor = ConsoleColor.Black;
}
void gameOver2()
{
    runGame = false;
    Console.Clear();
    Console.WriteLine($"Tillykke, {navn2} det gik da godt. Tillykke med de 20 point.");
    Console.WriteLine($"{navn1}, Bedre held næste gang :) Din score var {score1}");
    Console.WriteLine("Tryk på en tast for at lukke spillet");
    Console.ForegroundColor = ConsoleColor.Black;
}
void boldRemove(int x, int y)
{
    Console.SetCursorPosition(x, y);
    Console.Write(" ");
}
void boldStart()
{
    if (rand.Next(0, 2) == 0)
    {
        hastighedX = -1;
    }
    else
    {
        hastighedX = 1;
    }
    if (rand.Next(0, 2) == 0)
    {
        hastighedY = -1;
    }
    else
    {
        hastighedY = 1;
    }
    boldX = rand.Next(40, 79);
    boldY = rand.Next(15, 28);
}
void point1()
{
    score1 += 1;
    boldStart();
}
void point2()
{
    score2 += 1;
    boldStart();
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
        point1();
    }
    else if (hitBat())
    {
        boldRemove(boldX, boldY);
        hastighedX = -hastighedX;
        boldX += hastighedX;
        boldY += hastighedY;
        boldDraw(boldX, boldY);
    }
    else if (hitBat2())
    {
        boldRemove(boldX, boldY);
        hastighedX = -hastighedX;
        boldX += hastighedX;
        boldY += hastighedY;
        boldDraw(boldX, boldY);
    }
    else if (hitLeftWall())
    {
        boldRemove(boldX, boldY);
        point2();
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
    Console.Write("Spiller 1, skriv dit navn:");
    navn1 = Console.ReadLine();
    Console.WriteLine("Navn registreret... Hej " + navn1);
    Console.Write("Spiller 2, skriv dit navn:");
    navn2 = Console.ReadLine();
    Console.WriteLine("Navn registreret... Hej " + navn2);
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
    boldStart();
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
            if ((score1 > 10 && score2 < 10) || (score2 > 10 && score1 < 10)) 
                {
                spilHastighed = 60;
                }
            if (score1 == 20)
            {
                gameOver1();
            }
            if (score2 == 20)
            {
                gameOver2();
            }
            BallMoveDeltaTime = TimeSpan.FromMilliseconds(spilHastighed);

            for (int i = 0; i < batHøjde; i++)
            {
                Console.SetCursorPosition(batX, batY + i);
                Console.Write("█");
            }
            for (int i = 0; i < bat2Højde; i++)
            {
                Console.SetCursorPosition(bat2X, bat2Y + i);
                Console.Write("█");
            }
            if (batY < laneDY - 2)
            {
                Console.SetCursorPosition(batX, batY + batHøjde);
                Console.Write(" ");
            }
            if (bat2Y < laneDY - 2)
            {
                Console.SetCursorPosition(bat2X, bat2Y + bat2Højde);
                Console.Write(" ");
            }
            if (batY == laneDY - batHøjde)
            {
                Console.SetCursorPosition(batX, laneDY);
                Console.Write("─");
            }
            if (bat2Y == laneDY - bat2Højde)
            {
                Console.SetCursorPosition(bat2X, laneDY);
                Console.Write("─");
            }
            if (batY > laneY + 1)
            {
                Console.SetCursorPosition(batX, batY - 1);
                Console.Write(" ");
            }
            if (bat2Y > laneY + 1)
            {
                Console.SetCursorPosition(bat2X, bat2Y - 1);
                Console.Write(" ");
            }
            Console.SetCursorPosition(20, 5);
            Console.WriteLine(score1);
            Console.SetCursorPosition(80, 5);
            Console.WriteLine(score2);

            Console.SetCursorPosition(boldX, boldY);
            Console.WriteLine(boldTegn);

            if (Console.KeyAvailable)
            {
                tast = Console.ReadKey(true).Key;

            
                switch (tast)
                {
                    case ConsoleKey.S:
                        if (batY < laneDY - batHøjde) { batY++; };
                        break;
                    case ConsoleKey.W:
                        if (batY > laneY + 1) { batY--; }
                        break;
                    case ConsoleKey.Escape:
                        stop();
                        break;
                    case ConsoleKey.UpArrow:
                        if (bat2Y > laneY + 1) { bat2Y--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if (bat2Y < laneDY - bat2Højde) { bat2Y++; }
                        break;
                }
            }
        }
  
    } while (runGame == true);
}