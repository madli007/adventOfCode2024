// See https://aka.ms/new-console-template for more information

using Day_10;
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

List<PointWithDirection> unfinishedCheckpoints = [];

bool startProcedure(Point startingPoint, int[,] map)
{
    int minX = 0;
    int minY = 0;
    int maxX = map.GetLength(0) - 1;
    int maxY = map.GetLength(1) - 1;

    List<PointWithDirection> pointsWithDirections = [];

    if (startingPoint.X + 1 <= maxX && map[startingPoint.X + 1, startingPoint.Y] == map[startingPoint.X, startingPoint.Y] + 1)
    {
        Point tempPoint = new(startingPoint.X + 1, startingPoint.Y);
        Direction d = Direction.Right;
        pointsWithDirections.Add(new(tempPoint, d));
    }

    if (startingPoint.X - 1 >= minX && map[startingPoint.X - 1, startingPoint.Y] == map[startingPoint.X, startingPoint.Y] + 1)
    {
        Point tempPoint = new(startingPoint.X - 1, startingPoint.Y);
        Direction d = Direction.Left;
        pointsWithDirections.Add(new(tempPoint, d));
    }

    if (startingPoint.Y + 1 <= maxY && map[startingPoint.X, startingPoint.Y + 1] == map[startingPoint.X, startingPoint.Y] + 1)
    {
        Point tempPoint = new(startingPoint.X, startingPoint.Y + 1);
        Direction d = Direction.Down;
        pointsWithDirections.Add(new(tempPoint, d));
    }

    if (startingPoint.Y - 1 >= minY && map[startingPoint.X, startingPoint.Y - 1] == map[startingPoint.X, startingPoint.Y] + 1)
    {
        Point tempPoint = new(startingPoint.X, startingPoint.Y - 1);
        Direction d = Direction.Up;
        pointsWithDirections.Add(new(tempPoint, d));
    }

    if (pointsWithDirections.Count > 0)
    {
        if (pointsWithDirections.Count > 1)
        {
            // add all but first one to unfinished list
            unfinishedCheckpoints.AddRange([.. pointsWithDirections.GetRange(1, pointsWithDirections.Count - 1)]);
        }
        startProcedure(pointsWithDirections.First().Point, map);
        Console.WriteLine(pointsWithDirections.First().ToString() + " => " + map[pointsWithDirections.First().Point.X, pointsWithDirections.First().Point.Y].ToString());
    }
    
    if (map[startingPoint.X, startingPoint.Y] == 9)
    {
        return true;
    }
    return false;
}

int sum = 0;

for (int i = 0; i < startingPoints.Count; i++)
{
    bool yo = startProcedure(startingPoints[i], map);
    if (yo)
    {
        sum++;
    }
}

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