// See https://aka.ms/new-console-template for more information

using System.Drawing;

Console.WriteLine("Naloga 15");

string[] lines = Helper.Helper.GetAllInputsFromTxt(15, true);

char robot = '@';
char box = 'O';
char wall = '#';
char up = '^';
char down = 'v';
char left = '<';
char right = '>';

// parse
List<string> mapLines = lines.Where(x => x.Contains(wall)).ToList();
List<string> instructions = lines.Where(x => !x.Contains(wall) && !string.IsNullOrEmpty(x)).ToList();
string joinedInstructions = string.Join("", [.. instructions]);

int lineLength = mapLines[0].Length;
int numberOfLines = mapLines.Count;

//Point robotPosition = new();

//char[,] map = new char[lineLength, numberOfLines];
List<List<char>> map = [];

for (int i = 0; i < numberOfLines; i++)
{
    List<char> chars = [];
    for (int j = 0; j < lineLength; j++)
    {
        chars.Add(mapLines[i][j]);
        //map[j, i] = mapLines[i][j];
        
        //if (map[j, i] == robot)
        //{
        //    robotPosition.X = j;
        //    robotPosition.Y = i;
        //}
    }
    map.Add(chars);
}

// izris
void DrawMap(List<List<char>> map)
{
    if (map.Count == 0)
    {
        return;
    }

    Console.WriteLine();
    for (int i = 0; i < map.Count; i++)
    {
        for (int j = 0; j < map[0].Count; j++)
        {
            Console.Write(mapLines[i][j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

List<List<char>> MoveRobot(List<List<char>> map, char direction)
{
    var position = map
            .SelectMany((row, rowIndex) => row
                .Select((ch, colIndex) => new { ch, rowIndex, colIndex }))
            .FirstOrDefault(item => item.ch == robot);

    Point robotPosition = new()
    {
        X = position.colIndex,
        Y = position.rowIndex
    };

    if (direction.Equals(right))
    {
        Point p = new(robotPosition.X + 1, robotPosition.Y);
        List<char> line = map[p.Y];
    }

    else if (direction.Equals(left))
    {
        Point p = new(robotPosition.X - 1, robotPosition.Y);
        List<char> line = map[p.Y];
    }

    else if (direction.Equals(up))
    {
        Point p = new(robotPosition.X, robotPosition.Y - 1);
        List<char> line = map[p.Y];
    }

    else if (direction.Equals(down))
    {
        Point p = new(robotPosition.X, robotPosition.Y + 1);
        List<char> line = map[p.Y];
    }


    return map;
}

DrawMap(map);

foreach (char direction in joinedInstructions)
{
    map = MoveRobot(map, direction);
    DrawMap(map);
}

int sum = 0;

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(15, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;

Console.WriteLine("Sum: " + sum2);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(15, 2, sum2));