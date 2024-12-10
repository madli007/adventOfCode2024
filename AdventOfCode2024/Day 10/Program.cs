// See https://aka.ms/new-console-template for more information

using System.Drawing;

Console.WriteLine("Naloga 10");

string[] lines = Helper.Helper.GetAllInputsFromTxt(10, true);

int lineLength = lines[0].Length;
int numberOfLines = lines.Length;

int[,] map = new int[lineLength, numberOfLines];
List<Point> startingPoints = [];

for (int i = 0; i < numberOfLines; i++)
{
    for (int j = 0; j < lineLength; j++)
    {
        map[j, i] = int.Parse(lines[i][j].ToString());

        if (map[j, i] == 0)
        {
            startingPoints.Add(new Point(j, i));
        }
    }
}

int sum = 0;

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(10, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;

Console.WriteLine("Sum: " + sum2);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(10, 2, sum2));