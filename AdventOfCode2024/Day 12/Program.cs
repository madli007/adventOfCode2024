// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Numerics;

Console.WriteLine("Naloga 12");

string[] lines = Helper.Helper.GetAllInputsFromTxt(12, true);

int lineLength = lines[0].Length;
int numberOfLines = lines.Length;

char[,] map = new char[lineLength, numberOfLines];

for (int i = 0; i < numberOfLines; i++)
{
    for (int j = 0; j < lineLength; j++)
    {
        map[j, i] = lines[i][j];
    }
}

int sum = 0;

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(12, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;

Console.WriteLine("Sum: " + sum2);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(12, 2, sum2));