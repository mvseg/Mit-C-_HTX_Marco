int boldX;
int boldY;
int hastighedX;
int hastighedY;

var rand  = new Random();

rand.Next(-1, 1);
if (rand.Next(0, 2) == 0)
{
    hastighedX = -1;
}
else
{
    hastighedX = 1;
}
Console.WriteLine(hastighedX);