// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

Console.WriteLine("Naloga 4");
Console.WriteLine();

string[] lines = Helper.Helper.GetAllInputsFromTxt(4, true);

int lineLength = lines[0].Length;
int numberOfLines = lines.Length;

char[,] tableMatrix = new char[lineLength,numberOfLines];
for (int i = 0; i < numberOfLines; i++)
{
    for (int j = 0; j < lineLength; j++)
    {
        tableMatrix[j, i] = lines[i][j];
    }
    Console.WriteLine(lines[i]);
}

Console.WriteLine();

// get all strings into single list (rows, columns, diagonals)
List<string> allCombos = [];

// rows
foreach (string line in lines)
{
    allCombos.Add(line);
}

// columns
for (int i = 0; i < lineLength; i++)
{
    string tempString = string.Empty;
    for (int j = 0; j < numberOfLines; j++)
    {
        tempString += tableMatrix[i, j];
    }
    Console.WriteLine(tempString);

    allCombos.Add(tempString);
}

// diagonals from left to right part 1 (bottom part of the square)
Console.WriteLine();

int x;
int y;

for (int i = 0; i < numberOfLines; i++)
{
    string tempString = string.Empty;
    x = 0;
    y = i;

    for (int j = 0; j < lineLength; j++)
    {
        if (x < lineLength && y < numberOfLines)
        {
            tempString += tableMatrix[x, y];
        }
        y++;
        x++;
    }

    Console.WriteLine(tempString);
    allCombos.Add(tempString);
}

// diagonals from left to right part 2 (upper part of the square), start from 2nd column, to not include the same diagonal
Console.WriteLine();

for (int i = 1; i < lineLength; i++)
{
    string tempString = string.Empty;
    x = i;
    y = 0;

    for (int j = 0; j < numberOfLines; j++)
    {
        if (x < lineLength && y < numberOfLines)
        {
            tempString += tableMatrix[x, y];
        }
        y++;
        x++;
    }

    Console.WriteLine(tempString);
    allCombos.Add(tempString);
}

// diagonals from right to left part 1 (bottom part of the square)
Console.WriteLine();

for (int i = 0; i < numberOfLines; i++)
{
    string tempString = string.Empty;
    x = lineLength - 1;
    y = i;

    for (int j = lineLength; j > 0; j--)
    {
        if (x < lineLength && y < numberOfLines && x >= 0)
        {
            tempString += tableMatrix[x, y];
        }
        y++;
        x--;
    }

    Console.WriteLine(tempString);
    allCombos.Add(tempString);
}

// diagonals from right to left part 2 (upper part of the square), start from 2nd to left column, to not include the same diagonal
Console.WriteLine();

for (int i = lineLength - 2; i >= 0; i--)
{
    string tempString = string.Empty;
    x = i;
    y = 0;

    for (int j = 0; j < numberOfLines; j++)
    {
        if (x < lineLength && y < numberOfLines && x >= 0)
        {
            tempString += tableMatrix[x, y];
        }
        y++;
        x--;
    }

    Console.WriteLine(tempString);
    allCombos.Add(tempString);
}

// end of preparing data

int sum = 0;
Regex regex = new("(?=(XMAS))|(?=(SAMX))"); // https://stackoverflow.com/questions/320448/overlapping-matches-in-regex

foreach (string combo in allCombos)
{
    int matches = regex.Matches(combo).Count;
    sum += matches;
}

Console.WriteLine();
Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(4, 1, sum));