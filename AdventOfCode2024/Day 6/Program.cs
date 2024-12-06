// See https://aka.ms/new-console-template for more information


using System.Drawing;

Console.WriteLine("Naloga 6");
Console.WriteLine();

string[] lines = Helper.Helper.GetAllInputsFromTxt(6, true);

int lineLength = lines[0].Length;
int numberOfLines = lines.Length;

char[,] map = new char[lineLength, numberOfLines];
char[,] markedMap = new char[lineLength, numberOfLines];
char obstacle = '#';
char[] guard = ['^', '<', '>', 'ˇ'];
Point guardCoordinates = new();
bool guardFound = false;

// parse
for (int i = 0; i < numberOfLines; i++)
{
    for (int j = 0; j < lineLength; j++)
    {
        map[j, i] = lines[i][j];
        markedMap[j, i] = lines[i][j];

        if (!guardFound)
        {
            for (int k = 0; k < guard.Length; k++)
            {
                if (map[j, i] == guard[k])
                {
                    guardCoordinates.X = j;
                    guardCoordinates.Y = i;
                    guardFound = true;
                }
            }
        }
    }
    Console.WriteLine(lines[i]);
}

int sum = 0;

// move guard
while (guardCoordinates.X >= 0 && guardCoordinates.X < lineLength &&
    guardCoordinates.Y >= 0 && guardCoordinates.Y < numberOfLines)
{
    markedMap[guardCoordinates.X, guardCoordinates.Y] = 'X';

    // get direction
    if (map[guardCoordinates.X, guardCoordinates.Y] == '>')
    {
        if (guardCoordinates.X + 1 > lineLength - 1)
        {
            break;
        }

        if (map[guardCoordinates.X + 1, guardCoordinates.Y] != obstacle)
        {
            map[guardCoordinates.X, guardCoordinates.Y] = '.';
            guardCoordinates.X++;
            map[guardCoordinates.X, guardCoordinates.Y] = '>';
        }
        else
        {
            map[guardCoordinates.X, guardCoordinates.Y] = '˘';
        }
    }

    else if (map[guardCoordinates.X, guardCoordinates.Y] == '<')
    {
        if (guardCoordinates.X - 1 < 0)
        {
            break;
        }

        if (map[guardCoordinates.X - 1, guardCoordinates.Y] != obstacle)
        {
            map[guardCoordinates.X, guardCoordinates.Y] = '.';
            guardCoordinates.X--;
            map[guardCoordinates.X, guardCoordinates.Y] = '<';
        }
        else
        {
            map[guardCoordinates.X, guardCoordinates.Y] = '^';
        }
    }

    else if (map[guardCoordinates.X, guardCoordinates.Y] == '^')
    {
        if (guardCoordinates.Y - 1 < 0)
        {
            break;
        }

        if (map[guardCoordinates.X, guardCoordinates.Y - 1] != obstacle)
        {
            map[guardCoordinates.X, guardCoordinates.Y] = '.';
            guardCoordinates.Y--;
            map[guardCoordinates.X, guardCoordinates.Y] = '^';
        }
        else
        {
            map[guardCoordinates.X, guardCoordinates.Y] = '>';
        }
    }

    else if (map[guardCoordinates.X, guardCoordinates.Y] == '˘')
    {
        if (guardCoordinates.Y + 1 > numberOfLines - 1)
        {
            break;
        }

        if (map[guardCoordinates.X, guardCoordinates.Y + 1] != obstacle)
        {
            map[guardCoordinates.X, guardCoordinates.Y] = '.';
            guardCoordinates.Y++;
            map[guardCoordinates.X, guardCoordinates.Y] = '˘';
        }
        else
        {
            map[guardCoordinates.X, guardCoordinates.Y] = '<';
        }
    }
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Marked map:");

for (int i = 0; i < numberOfLines; i++)
{
    for (int j = 0; j < lineLength; j++)
    {
        Console.Write(markedMap[j, i]);
        if (markedMap[j, i] == 'X')
        {
            sum++;
        }
    }
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(6, 1, sum));

// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;

Console.WriteLine("Sum: " + sum2);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(6, 2, sum2));