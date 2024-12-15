// See https://aka.ms/new-console-template for more information

using Day_14;
using System.Drawing;

Console.WriteLine("Naloga 14");

string[] lines = Helper.Helper.GetAllInputsFromTxt(14, false);

List<Robot> robots = [];

// parse
foreach (string line in lines)
{
    Robot robot = new();
    string[] split = line.Split(" ");
    string stringPosition = split[0].Split("=")[1];
    string stringVelocity = split[1].Split("=")[1];
    string[] splitPositions = stringPosition.Split(",");
    string[] splitVelocity = stringVelocity.Split(",");

    robot.Position = new Point(int.Parse(splitPositions[0]), int.Parse(splitPositions[1]));
    robot.Velocity = new Point(int.Parse(splitVelocity[0]), int.Parse(splitVelocity[1]));

    robots.Add(robot);
}


List<Robot> newRobotPositions = [];
int mapWidth = 101;
int mapHeight = 103;
int secondsExpired = 100;

foreach (Robot robot in robots)
{
    Robot r = new();
    Point position = new(robot.Position.X, robot.Position.Y);
    Point velocity = new(robot.Velocity.X, robot.Velocity.Y);
    r.Velocity = velocity;

    position.X += velocity.X * secondsExpired;
    position.Y += velocity.Y * secondsExpired;

    // out of bounds calculation
    position.X %= mapWidth;
    position.Y %= mapHeight;

    if (position.X < 0)
    {
        position.X = mapWidth - Math.Abs(position.X);
    }

    if (position.Y < 0)
    {
        position.Y = mapHeight - Math.Abs(position.Y);
    }

    r.Position = position;

    newRobotPositions.Add(r);
}

// print out robots and save to to matrix
string[,] map = new string[mapWidth, mapHeight];
Console.WriteLine();
for (int i = 0; i < mapHeight; i++)
{
    for (int j = 0; j < mapWidth; j++)
    {
        if (j == mapWidth / 2)
        {
            Console.Write(" ");
            continue;
        }

        if (i == mapHeight / 2)
        {
            continue;
        }

        int numberOfRobotsFound = newRobotPositions.FindAll(x => x.Position.X == j && x.Position.Y == i).Count;
        if (numberOfRobotsFound > 0)
        {
            Console.Write(numberOfRobotsFound.ToString());
            map[j, i] = numberOfRobotsFound.ToString();
        }
        else
        {
            Console.Write(".");
            map[j, i] = ".";
        }
    }

    if (i == mapHeight / 2)
    {
        Console.WriteLine();
    }
    
    Console.WriteLine();
}
Console.WriteLine();

int GetQuadrantNumberOfRobots(int quadrant, string[,] map)
{
    int sum = 0;
    int minI = 0;
    int maxI = 0;
    int minJ = 0;
    int maxJ = 0;

    switch (quadrant)
    {
        case 1:
            minJ = 0;
            maxJ = map.GetLength(0) / 2;
            minI = 0;
            maxI = map.GetLength(1) / 2;
            break;
        case 2:
            minJ = map.GetLength(0) / 2;
            maxJ = map.GetLength(0);
            minI = 0;
            maxI = map.GetLength(1) / 2;
            break;
        case 3:
            minJ = 0;
            maxJ = map.GetLength(0) / 2;
            minI = map.GetLength(1) / 2;
            maxI = map.GetLength(1);
            break;
        case 4:
            minJ = map.GetLength(0) / 2;
            maxJ = map.GetLength(0);
            minI = map.GetLength(1) / 2;
            maxI = map.GetLength(1);
            break;
    }

    for (int i = minI; i < maxI; i++)
    {
        for (int j = minJ; j < maxJ; j++)
        {
            string s = map[j, i];
            _ = int.TryParse(s, out int value);
            sum += value;
        }
    }
    return sum;
}

int quadrant1 = GetQuadrantNumberOfRobots(1, map);
int quadrant2 = GetQuadrantNumberOfRobots(2, map);
int quadrant3 = GetQuadrantNumberOfRobots(3, map);
int quadrant4 = GetQuadrantNumberOfRobots(4, map);

Console.WriteLine();
Console.WriteLine("Quadrant 1: " + quadrant1);
Console.WriteLine("Quadrant 2: " + quadrant2);
Console.WriteLine("Quadrant 3: " + quadrant3);
Console.WriteLine("Quadrant 4: " + quadrant4);
Console.WriteLine();

int sum = quadrant1 * quadrant2 * quadrant3 * quadrant4;

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(14, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

for (int counter = 0; counter < 150; counter++)
{
    secondsExpired = counter;
    newRobotPositions = [];
    foreach (Robot robot in robots)
    {
        Robot r = new();
        Point position = new(robot.Position.X, robot.Position.Y);
        Point velocity = new(robot.Velocity.X, robot.Velocity.Y);
        r.Velocity = velocity;

        position.X += velocity.X * secondsExpired;
        position.Y += velocity.Y * secondsExpired;

        // out of bounds calculation
        position.X %= mapWidth;
        position.Y %= mapHeight;

        if (position.X < 0)
        {
            position.X = mapWidth - Math.Abs(position.X);
        }

        if (position.Y < 0)
        {
            position.Y = mapHeight - Math.Abs(position.Y);
        }

        r.Position = position;

        newRobotPositions.Add(r);
    }

    using StreamWriter outputFile = new("WriteLines" + counter.ToString() + ".txt");

    outputFile.WriteLine();
    for (int i = 0; i < mapHeight; i++)
    {
        for (int j = 0; j < mapWidth; j++)
        {
            if (j == mapWidth / 2)
            {
                outputFile.Write(" ");
                continue;
            }

            if (i == mapHeight / 2)
            {
                continue;
            }

            int numberOfRobotsFound = newRobotPositions.FindAll(x => x.Position.X == j && x.Position.Y == i).Count;
            if (numberOfRobotsFound > 0)
            {
                outputFile.Write(numberOfRobotsFound.ToString());
            }
            else
            {
                outputFile.Write(".");
            }
        }

        if (i == mapHeight / 2)
        {
            outputFile.WriteLine();
        }

        outputFile.WriteLine();
    }
    outputFile.WriteLine();
}

int sum2 = 0;

Console.WriteLine("Sum: " + sum2);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(14, 2, sum2));