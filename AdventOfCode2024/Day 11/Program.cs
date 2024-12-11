// See https://aka.ms/new-console-template for more information

using System.Numerics;

Console.WriteLine("Naloga 11");

string[] lines = Helper.Helper.GetAllInputsFromTxt(11, false);

List<BigInteger> numbers = [];

foreach (string line in lines)
{
    string[] split = line.Split(' ');
    foreach (string splitString in split)
    {
        numbers.Add(int.Parse(splitString));
    }
}

int GetNumberOfStones(int numberOfBlinks)
{
    for (int i = 0; i < numberOfBlinks; i++)
    {
        List<BigInteger> newNumbers = [];

        for (int j = 0; j < numbers.Count; j++)
        {
            if (numbers[j] == 0)
            {
                newNumbers.Add(1);
            }
            else if (numbers[j].ToString().Length % 2 == 0)
            {
                BigInteger number1 = BigInteger.Parse(numbers[j].ToString().Substring(0, numbers[j].ToString().Length / 2));
                BigInteger number2 = BigInteger.Parse(numbers[j].ToString().Substring(numbers[j].ToString().Length / 2));

                newNumbers.Add(number1);
                newNumbers.Add(number2);
            }
            else
            {
                BigInteger number = numbers[j] * 2024;
                newNumbers.Add(number);
            }
        }
        numbers = newNumbers;
    }

    return numbers.Count;
}

int sum = GetNumberOfStones(25);

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(11, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;

Console.WriteLine("Sum: " + sum2);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(11, 2, sum2));