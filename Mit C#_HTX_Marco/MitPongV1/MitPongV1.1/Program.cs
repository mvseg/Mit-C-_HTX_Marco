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
int laneY = 7;
int laneDY = 29;
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
int bat1Rot = 2;
int bat2Rot = 2;
bool checkBat;

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
bool hitVertBat1()
{
    if (((boldX == batX + 1) && hastighedX == -1) && boldY >= batY && boldY <= batY + batHøjde - 1)
    {
        return true;
    }
    return false;
}
bool hitRightBat1()
{
    checkBat = false;
    for (int i = 0; i < batHøjde; i++)
    {
        if ((boldX == batX + 1 + i && boldY == batY + i && boldY <= batY + batHøjde - 1 && hastighedX == -1 && hastighedY == 1) ||
            (boldX == batX + i && boldY == batY + i && boldY <= batY + batHøjde - 1 && hastighedX == -1 && hastighedY == 1) ||
            (boldX == batX + batHøjde && boldY == batY + batHøjde && hastighedX == -1 && hastighedY == -1) ||
            (boldX == batX + batHøjde + 1 && boldY == batY + batHøjde + 1 && hastighedX == -1 && hastighedY == -1))
        {
            checkBat = true;
        }
    }
    if (checkBat == true)
    {
        return true;
    }
    return false;
}
bool hitLeftBat1()
{
    checkBat = false;
    for (int i = 0; i < batHøjde; i++)
    {

        if ((boldX == batX + 1 - i && boldY == batY + i && boldY <= batY + batHøjde - 1 && hastighedX == -1 && hastighedY == -1) ||
            (boldX == batX - i && boldY == batY + i && boldY <= batY + batHøjde - 1 && hastighedX == -1 && hastighedY == -1) ||
            (boldX == batX + 1 && boldY == batY - 1 && hastighedX == -1 && hastighedY == 1) ||
            (boldX == batX && boldY == batY && hastighedX == -1 && hastighedY == 1))
        {
            checkBat = true;
        }
    }
    if (checkBat == true)
    {
        return true;
    }
    return false;
}
bool hitVertBat2()
{
    if (((boldX == bat2X - 1) && hastighedX == 1) && boldY >= bat2Y && boldY <= bat2Y + batHøjde - 1)
    {
        return true;
    }
    return false;
}
bool hitRightBat2()
{
    checkBat = false;
    for (int i = 0; i < batHøjde; i++)
    {
        if ((boldX == bat2X - 1 + i && boldY == bat2Y + i && boldY <= bat2Y + batHøjde - 1 && hastighedX == 1 && hastighedY == -1) ||
            (boldX == bat2X + i && boldY == bat2Y + i && boldY <= bat2Y + batHøjde - 1 && hastighedX == 1 && hastighedY == -1) ||
            (boldX == bat2X - 1 && boldY == bat2Y - 1 && hastighedX == 1 && hastighedY == 1) ||
            (boldX == bat2X && boldY == bat2Y && hastighedX == 1 && hastighedY == 1))
        {
            checkBat = true;
        }
    }
    if (checkBat == true)
    {
        return true;
    }
    return false;
}
bool hitLeftBat2()
{
    checkBat = false;
    for (int i = 0; i < batHøjde; i++)
    {
        if ((boldX == bat2X - 1 - i && boldY == bat2Y + i && boldY <= bat2Y + batHøjde - 1 && hastighedX == 1 && hastighedY == 1) ||
            (boldX == bat2X - i && boldY == bat2Y + i && boldY <= bat2Y + batHøjde - 1 && hastighedX == 1 && hastighedY == 1) ||
            (boldX == bat2X - batHøjde && boldY == bat2Y + batHøjde && hastighedX == 1 && hastighedY == -1) ||
            (boldX == bat2X - batHøjde + 1 && boldY == bat2Y + batHøjde - 1 && hastighedX == 1 && hastighedY == -1))
        {
            checkBat = true;
        }
    }
    if (checkBat == true)
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
    Console.WriteLine($"Tillykke, {navn1} det gik da godt. Tillykke med de {score1} point.");
    Console.WriteLine($"{navn2}, Bedre held næste gang :) Din score var {score2}");
    Console.WriteLine("Tryk på en tast for at lukke spillet");
    Console.ForegroundColor = ConsoleColor.Black;
}
void gameOver2()
{
    runGame = false;
    Console.Clear();
    Console.WriteLine($"Tillykke, {navn2} det gik da godt. Tillykke med de {score2} point.");
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
    if(score1 < 5 && score2 < 5)
    {
        spilHastighed = 100;
    }
    else
    {
        spilHastighed = 60;
    }
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
void removeVertBat1()
{
    for (int i = 0; i < batHøjde; i++)
    {
        Console.SetCursorPosition(batX, batY + i);
        Console.Write(" ");
    }
}
void drawVertBat1()
{
    for (int i = 0; i < batHøjde; i++)
    {
        Console.SetCursorPosition(batX, batY + i);
        Console.Write("█");
    }
}
void removeRightBat1()
{
    for (int i = 0; i < batHøjde; i++)
    {
        Console.SetCursorPosition(batX + i, batY + i);
        Console.Write(" ");
    }
}
void drawRightBat1()
{
    for (int i = 0; i < batHøjde; i++)
    {
        Console.SetCursorPosition(batX + i, batY + i);
        Console.Write("█");
    }
}
void removeLeftBat1()
{
    for (int i = 0; i < batHøjde; i++)
    {
        Console.SetCursorPosition(batX - i, batY + i);
        Console.Write(" ");
    }
}
void drawLeftBat1()
{
    for (int i = 0; i < batHøjde; i++)
    {
        Console.SetCursorPosition(batX - i, batY + i);
        Console.Write("█");
    }
}
void removeVertBat2()
{
    for (int i = 0; i < bat2Højde; i++)
    {
        Console.SetCursorPosition(bat2X, bat2Y + i);
        Console.Write(" ");
    }
}
void drawVertBat2()
{
    for (int i = 0; i < bat2Højde; i++)
    {
        Console.SetCursorPosition(bat2X, bat2Y + i);
        Console.Write("█");
    }
}
void removeRightBat2()
{
    for (int i = 0; i < bat2Højde; i++)
    {
        Console.SetCursorPosition(bat2X + i, bat2Y + i);
        Console.Write(" ");
    }
}
void drawRightBat2()
{
    for (int i = 0; i < bat2Højde; i++)
    {
        Console.SetCursorPosition(bat2X + i, bat2Y + i);
        Console.Write("█");
    }
}
void removeLeftBat2()
{
    for (int i = 0; i < bat2Højde; i++)
    {
        Console.SetCursorPosition(bat2X - i, bat2Y + i);
        Console.Write(" ");
    }
}
void drawLeftBat2()
{
    for (int i = 0; i < bat2Højde; i++)
    {
        Console.SetCursorPosition(bat2X - i, bat2Y + i);
        Console.Write("█");
    }
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
    else if (hitLeftBat1() && bat1Rot == 1)
    {
        boldRemove(boldX, boldY);
        hastighedX = -hastighedX;
        hastighedY = -hastighedY;
        boldX += hastighedX;
        boldY += hastighedY;
        spilHastighed -= 5;
        boldDraw(boldX, boldY);
    }
        else if (hitVertBat1() && bat1Rot == 2)
        {
            boldRemove(boldX, boldY);
            hastighedX = -hastighedX;
            boldX += hastighedX;
            boldY += hastighedY;
            spilHastighed -= 5;
        boldDraw(boldX, boldY);
        }
    else if (hitRightBat1() && bat1Rot == 3)
    {
        boldRemove(boldX, boldY);
        hastighedX = -hastighedX;
        hastighedY = -hastighedY;
        boldX += hastighedX;
        boldY += hastighedY;
        spilHastighed -= 5;
        boldDraw(boldX, boldY);
    }
    else if (hitLeftBat2() && bat2Rot == 1)
    {
        boldRemove(boldX, boldY);
        hastighedX = -hastighedX;
        hastighedY = -hastighedY;
        boldX += hastighedX;
        boldY += hastighedY;
        spilHastighed -= 5;
        boldDraw(boldX, boldY);
    }
        else if (hitVertBat2() && bat2Rot == 2)
        {
            boldRemove(boldX, boldY);
            hastighedX = -hastighedX;
            boldX += hastighedX;
            boldY += hastighedY;
            spilHastighed -= 5;
        boldDraw(boldX, boldY);
        }
    else if (hitRightBat2() && bat2Rot == 3)
    {
        boldRemove(boldX, boldY);
        hastighedX = -hastighedX;
        hastighedY = -hastighedY;
        boldX += hastighedX;
        boldY += hastighedY;
        spilHastighed -= 5;
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
        Console.SetCursorPosition(laneX, laneDY);
        Console.Write("└");
        Console.SetCursorPosition(laneDX, laneDY);
        Console.Write("┘");
        boldStart();
    drawVertBat1();
    drawVertBat2();
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
                switch (bat1Rot)
                {
                    case 1:
                        { drawLeftBat1(); }
                        break;
                    case 2:
                        { drawVertBat1(); }
                        break;
                    case 3:
                        { drawRightBat1(); }
                        break;
                }
                switch (bat2Rot)
                {
                    case 1:
                        { drawLeftBat2(); }
                        break;
                    case 2:
                        { drawVertBat2(); }
                        break;
                    case 3:
                        { drawRightBat2(); }
                        break;
                }
                }
                if (score1 == 10)
                {
                    gameOver1();
                }
                if (score2 == 10)
                {
                    gameOver2();
                }
                BallMoveDeltaTime = TimeSpan.FromMilliseconds(spilHastighed);

                if (batY == laneDY - batHøjde)
                {
                    Console.SetCursorPosition(batX, laneDY);
                    Console.Write("─");
                    Console.SetCursorPosition(batX+3, laneDY);
                    Console.Write("─");
                    Console.SetCursorPosition(batX-3, laneDY);
                    Console.Write("─");
                }
                if (bat2Y == laneDY - bat2Højde)
                {
                    Console.SetCursorPosition(bat2X, laneDY);
                    Console.Write("─");
                    Console.SetCursorPosition(bat2X + 3, laneDY);
                    Console.Write("─");
                    Console.SetCursorPosition(bat2X - 3, laneDY);
                    Console.Write("─");
            }
                if (batY == laneY + 1)
                {
                    Console.SetCursorPosition(batX, laneY);
                    Console.Write("─");
                }
                if (bat2Y == laneY + 1)
                {
                    Console.SetCursorPosition(bat2X, laneY);
                    Console.Write("─");
                }
                Console.SetCursorPosition(15, 5);
                Console.WriteLine($"{navn1}: {score1} point");
                Console.SetCursorPosition(85, 5);
                Console.WriteLine($"{navn2}: {score2} point");

                Console.SetCursorPosition(boldX, boldY);
                Console.WriteLine(boldTegn);

                if (Console.KeyAvailable)
                {
                    tast = Console.ReadKey(true).Key;


                    switch (tast)
                    {
                    case ConsoleKey.A:
                        if (bat1Rot > 1)
                        {
                            removeVertBat1();
                            removeRightBat1();
                            bat1Rot--;
                            switch (bat1Rot)
                            {
                                case 1:
                                    drawLeftBat1();
                                    break;
                                case 2:
                                    drawVertBat1();
                                    break;
                                case 3:
                                    drawRightBat1();
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D:
                        if (bat1Rot < 3)
                        {
                            removeVertBat1();
                            removeLeftBat1();
                            bat1Rot++;
                            switch (bat1Rot)
                            {
                                case 1:
                                    drawLeftBat1();
                                    break;
                                case 2:
                                    drawVertBat1();
                                    break;
                                case 3:
                                    drawRightBat1();
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.S:
                            if (batY < laneDY - batHøjde + 1) 
                        {
                            switch (bat1Rot)
                            {
                                case 1:
                                    removeLeftBat1();
                                    batY++;
                                    drawLeftBat1();
                                    break;
                                case 2:
                                    removeVertBat1();
                                    batY++;
                                    drawVertBat1();
                                    break;
                                case 3:
                                    removeRightBat1();
                                    batY++;
                                    drawRightBat1();
                                    break;
                            }
                            break;
                        }
                            break;
                        case ConsoleKey.W:
                            if (batY > laneY) 
                        {
                            switch (bat1Rot)
                            {
                                case 1:
                                    removeLeftBat1();
                                    batY--;
                                    drawLeftBat1();
                                    break;
                                case 2:
                                    removeVertBat1();
                                    batY--;
                                    drawVertBat1();
                                    break;
                                case 3:
                                    removeRightBat1();
                                    batY--;
                                    drawRightBat1();
                                    break;
                            }
                            break;
                        }
                            break;
                        case ConsoleKey.Escape:
                            stop();
                            break;
                        case ConsoleKey.UpArrow:
                        if (bat2Y > laneY)
                        {
                            switch (bat2Rot)
                            {
                                case 1:
                                    removeLeftBat2();
                                    bat2Y--;
                                    drawLeftBat2();
                                    break;
                                case 2:
                                    removeVertBat2();
                                    bat2Y--;
                                    drawVertBat2();
                                    break;
                                case 3:
                                    removeRightBat2();
                                    bat2Y--;
                                    drawRightBat2();
                                    break;
                            }
                            break;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                            if (bat2Y < laneDY - bat2Højde + 1) 
                        {
                            switch (bat2Rot)
                            {
                                case 1:
                                    removeLeftBat2();
                                    bat2Y++;
                                    drawLeftBat2();
                                    break;
                                case 2:
                                    removeVertBat2();
                                    bat2Y++;
                                    drawVertBat2();
                                    break;
                                case 3:
                                    removeRightBat2();
                                    bat2Y++;
                                    drawRightBat2();
                                    break;
                            }
                        }
                            break;
                    case ConsoleKey.LeftArrow:
                        if (bat2Rot > 1)
                        {
                            removeVertBat2();
                            removeRightBat2();
                            bat2Rot--;
                            switch (bat2Rot)
                            {
                                case 1:
                                    drawLeftBat2();
                                    break;
                                case 2:
                                    drawVertBat2();
                                    break;
                                case 3:
                                    drawRightBat2();
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (bat2Rot < 3)
                        {
                            removeVertBat2();
                            removeLeftBat2();
                            bat2Rot++;
                            switch (bat2Rot)
                            {
                                case 1:
                                    drawLeftBat2();
                                    break;
                                case 2:
                                    drawVertBat2();
                                    break;
                                case 3:
                                    drawRightBat2();
                                    break;
                            }
                        }
                        break;
                }
                }
            }
        } while (runGame == true);
 }