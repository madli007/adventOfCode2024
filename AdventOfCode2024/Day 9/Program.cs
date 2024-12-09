// See https://aka.ms/new-console-template for more information

using System.Numerics;

Console.WriteLine("Naloga 9");

string[] lines = Helper.Helper.GetAllInputsFromTxt(9, false);

List<int> diskMap = [];

foreach (string line in lines)
{
    foreach (char c in line)
    {
        diskMap.Add(int.Parse(c.ToString()));
    }
}

List<string> output = [];
int id = 0;
for (int i = 0; i < diskMap.Count; i++)
{
    if (i % 2 == 0)
    {
        for (int j = 0; j < diskMap[i]; j++)
        {
            output.Add(id.ToString());
        }
        id++;
    }
    else
    {
        for (int j = 0; j < diskMap[i]; j++)
        {
            output.Add(".");
        }
    }
}

Console.WriteLine(output);
Console.WriteLine();

List<string> output2 = [.. output];

// TODO: preuredit, mam napako, ker so idji prek 10 in potem pri urejanju ne upoštevam, da ma cifra 2 števki
for (int i = 0; i < output2.Count; i++)
{
    if (output2[i].Equals("."))
    {
        repeat:
        if (output2[^1] == ".")
        {
            output2.RemoveAt(output2.Count - 1);
            goto repeat;
        }

        output2[i] = output2[^1];
        output2.RemoveAt(output2.Count - 1);
    }
}

BigInteger sum = 0;

for (int i = 0; i < output2.Count; i++)
{
    Console.Write(output2[i]);
    if (!output2[i].Equals("."))
    {
        sum += i * int.Parse(output2[i].ToString());
    }
}

Console.WriteLine();

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(9, 1, (double)sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;

Console.WriteLine("Sum: " + sum2);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(9, 2, sum2));