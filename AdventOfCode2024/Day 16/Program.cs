// See https://aka.ms/new-console-template for more information


using System.Drawing;

Console.WriteLine("Naloga 16");

string[] lines = Helper.Helper.GetAllInputsFromTxt(16, true);

int lineLength = lines[0].Length;
int numberOfLines = lines.Length;

char start = 'S';
char end = 'E';
char wall = '#';
char up = '^';
char down = 'v';
char left = '<';
char right = '>';
char space = '.';

List<List<char>> map = [];

// parse
for (int i = 0; i < numberOfLines; i++)
{
    List<char> chars = [];
    for (int j = 0; j < lineLength; j++)
    {
        chars.Add(lines[i][j]);
    }
    map.Add(chars);
}

var position = map
            .SelectMany((row, rowIndex) => row
                .Select((ch, colIndex) => new { ch, rowIndex, colIndex }))
            .FirstOrDefault(item => item.ch == start);

Point startPosition = new()
{
    X = position.colIndex,
    Y = position.rowIndex
};

position = map
            .SelectMany((row, rowIndex) => row
                .Select((ch, colIndex) => new { ch, rowIndex, colIndex }))
            .FirstOrDefault(item => item.ch == end);

Point endPosition = new()
{
    X = position.colIndex,
    Y = position.rowIndex
};


//bool moveAvailable = true;
//char direction = right;

//while (moveAvailable)
//{

//}

// test
static int FindPathWithLowestPoints(List<List<char>> maze)
{
    int rows = maze.Count;
    int cols = maze[0].Count;

    // Directions: up, down, left, right
    var directions = new (int dRow, int dCol, string dir)[]
    {
        (-1, 0, "up"),   // Up
        (1, 0, "down"),  // Down
        (0, -1, "left"), // Left
        (0, 1, "right")  // Right (east)
    };

    // Find the start position
    (int startRow, int startCol) = FindStart(maze);

    // Priority queue for BFS with points (min-heap)
    var priorityQueue = new SortedSet<(int points, int row, int col, string direction)>
        (Comparer<(int points, int row, int col, string direction)>.Create(
            (a, b) => a.points == b.points ? 
                        (a.row == b.row ? a.col.CompareTo(b.col) : a.row.CompareTo(b.row)) 
                        : a.points.CompareTo(b.points)));

    // Parent dictionary to reconstruct the path
    var parent = new Dictionary<(int, int), (int, int)>();

    // Dictionary to store the minimum cost to reach a cell
    var cost = new Dictionary<(int, int), int>();

    // Initialize the queue with the starting direction set to "right" (east)
    priorityQueue.Add((0, startRow, startCol, "right"));
    cost[(startRow, startCol)] = 0;

    while (priorityQueue.Count > 0)
    {
        // Dequeue the cell with the least points
        var (currentPoints, currentRow, currentCol, currentDir) = priorityQueue.Min;
        priorityQueue.Remove(priorityQueue.Min);

        // If goal is reached
        if (maze[currentRow][currentCol] == 'E')
        {
            Console.WriteLine($"Goal found with points: {currentPoints}");
            PrintPath(parent, (startRow, startCol), (currentRow, currentCol));
            return currentPoints;
        }

        // Explore neighbors
        foreach (var (dRow, dCol, newDir) in directions)
        {
            int newRow = currentRow + dRow;
            int newCol = currentCol + dCol;

            if (IsValidMove(newRow, newCol, maze))
            {
                // Calculate new points (1 for moving + 1000 if direction changes)
                int turnCost = currentDir != newDir ? 1000 : 0;
                int newPoints = currentPoints + 1 + turnCost;

                // Update only if the new path has a lower cost
                if (!cost.ContainsKey((newRow, newCol)) || newPoints < cost[(newRow, newCol)])
                {
                    cost[(newRow, newCol)] = newPoints;
                    priorityQueue.Add((newPoints, newRow, newCol, newDir));
                    parent[(newRow, newCol)] = (currentRow, currentCol);
                }
            }
        }
    }

    Console.WriteLine("Goal not reachable.");
    return 0;
}

static (int, int) FindStart(List<List<char>> maze)
{
    for (int i = 0; i < maze.Count; i++)
    {
        for (int j = 0; j < maze[i].Count; j++)
        {
            if (maze[i][j] == 'S')
                return (i, j);
        }
    }

    throw new Exception("Start not found in the maze.");
}

static bool IsValidMove(int row, int col, List<List<char>> maze)
{
    return row >= 0 && row < maze.Count &&
           col >= 0 && col < maze[0].Count &&
           maze[row][col] != '#';
}

static void PrintPath(Dictionary<(int, int), (int, int)> parent, (int, int) start, (int, int) goal)
{
    var path = new Stack<(int, int)>();
    var current = goal;

    while (current != start)
    {
        path.Push(current);
        current = parent[current];
    }

    path.Push(start);

    Console.WriteLine("Path:");
    while (path.Count > 0)
    {
        var (row, col) = path.Pop();
        Console.WriteLine($"({row}, {col})");
    }
}


var maze = new List<List<char>>
{
    new List<char> { '#', '#', '#', '#', '#', '#' },
    new List<char> { '#', 'S', ' ', ' ', 'E', '#' },
    new List<char> { '#', ' ', '#', ' ', '#', '#' },
    new List<char> { '#', ' ', '#', ' ', '#', '#' },
    new List<char> { '#', '#', '#', '#', '#', '#' },
};

int sum = FindPathWithLowestPoints(map);
//

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(16, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;

Console.WriteLine("Sum: " + sum2);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(16, 2, sum2));