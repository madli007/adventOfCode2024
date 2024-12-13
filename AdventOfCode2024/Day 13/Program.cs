// See https://aka.ms/new-console-template for more information

using Day_13;
using System.Drawing;

Console.WriteLine("Naloga 13");

string[] lines = Helper.Helper.GetAllInputsFromTxt(13, false);

List<ClawMachine> machines = [];
ClawMachine tempMachine = new();

// parse
foreach (string line in lines)
{
    if (line.Contains("Button A"))
    {
        tempMachine = new();
        string[] buttonSplit = line.Split(": ");
        string[] coordsSplit = buttonSplit[1].Split(", ");
        string x = coordsSplit[0].Split("+")[1];
        string y = coordsSplit[1].Split("+")[1];
        tempMachine.A = new Point(int.Parse(x), int.Parse(y));
    }
    else if (line.Contains("Button B"))
    {
        string[] buttonSplit = line.Split(": ");
        string[] coordsSplit = buttonSplit[1].Split(", ");
        string x = coordsSplit[0].Split("+")[1];
        string y = coordsSplit[1].Split("+")[1];
        tempMachine.B = new Point(int.Parse(x), int.Parse(y));
    }
    else if (line.Contains("Prize"))
    {
        string[] prizeSplit = line.Split(": ");
        string[] coordsSplit = prizeSplit[1].Split(", ");
        string x = coordsSplit[0].Split("=")[1];
        string y = coordsSplit[1].Split("=")[1];
        tempMachine.Prize = new Point(int.Parse(x), int.Parse(y));

        machines.Add(tempMachine);
    }
}

int priceForA = 3;
int priceForB = 1;

// x+94
// x+22
// x=8400
// y+34
// y+67
// y=5400
/*
 * (a * 94) + (b * 22) = 8400
 * 94a + 22b = 8400
 * 
 * (a * 34) + (b * 67) = 5400
 * 34a + 67b = 5400
 * 
 * 128a + 89b = 13800
 * 128a + 89b - 13800 = 0
 */

int sum = 0;

foreach (ClawMachine machine in machines)
{
    int max = 100;
    int equationAValue = machine.A.X + machine.A.Y;
    int equationBValue = machine.B.X + machine.B.Y;
    int resultValue = machine.Prize.X + machine.Prize.Y;

    List<Point> possibleSolutions = [];

    // Iterate through all possible values of b
    for (int b = 0; b <= max; b++)
    {
        // Check if a is an integer
        if ((resultValue - equationBValue * b) % equationAValue == 0)
        {
            // Calculate a
            int a = (resultValue - equationBValue * b) / equationAValue;

            // Check if a is within the range
            if (a >= 0 && a <= max)
            {
                Console.WriteLine($"Solution: a = {a}, b = {b}");
                possibleSolutions.Add(new Point(a, b));
            }
        }
    }

    int solution = 0;

    if (possibleSolutions.Count > 0)
    {
        solution = possibleSolutions.Min(value => value.X * 3 + value.Y);
    }

    sum += solution;
}

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(13, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;

Console.WriteLine("Sum: " + sum2);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(13, 2, sum2));