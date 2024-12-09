// See https://aka.ms/new-console-template for more information

using System.Drawing;

Console.WriteLine("Naloga 8");

string[] lines = Helper.Helper.GetAllInputsFromTxt(8, true);

int lineLength = lines[0].Length;
int numberOfLines = lines.Length;

char[,] map = new char[lineLength, numberOfLines];
char[,] markedMap = new char[lineLength, numberOfLines];

for (int i = 0; i < numberOfLines; i++)
{
    for (int j = 0; j < lineLength; j++)
    {
        map[j, i] = lines[i][j];
        markedMap[j, i] = lines[i][j];
    }
}

int sum = 0;
Dictionary<char, List<Point>> listOfCharPositions = [];
List<Point> antinodesLocations = [];

for (int i = 0; i < numberOfLines; i++)
{
    for (int j = 0; j < lineLength; j++)
    {
        char c = map[j, i];
        Point point = new(j, i);
        if (c != '.')
        {
            if (listOfCharPositions.ContainsKey(c))
            {
                listOfCharPositions[c].Add(point);
            }
            else
            {
                listOfCharPositions.Add(c, [point]);
            }
        }
    }
}

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(8, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;

Console.WriteLine("Sum: " + sum2);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(8, 2, sum2));