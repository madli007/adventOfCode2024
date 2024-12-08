// See https://aka.ms/new-console-template for more information


using Day_7;
using System.Numerics;

Console.WriteLine("Naloga 7");
Console.WriteLine();

string[] lines = Helper.Helper.GetAllInputsFromTxt(7, false);

List<Equation> equations = [];

// parse
foreach (string line in lines)
{
    string[] split = line.Split(": ");
    string[] split2 = split[1].Split(' ');

    Equation equation = new()
    {
        Result = BigInteger.Parse(split[0])
    };

    foreach (string splitStrings in split2)
    {
        equation.Numbers.Add(BigInteger.Parse(splitStrings));
    }

    equations.Add(equation);
}

// test
static void PrintAllKLengthPerm(string str, int k, List<string> operators)
{
    int n = str.Length;
    PrintAllKLengthPermRec(str, "", n, k, operators);
}

// The main recursive method to print all possible strings of length k
static void PrintAllKLengthPermRec(string str, string prefix, int n, int k, List<string> operators)
{
    // Base case: k is 0, print prefix
    if (k == 0)
    {
        //Console.WriteLine(prefix);
        operators.Add(prefix);
        return;
    }

    // One by one add all characters from str and recursively 
    // call for k equals to k-1
    for (int i = 0; i < n; i++)
    {
        // Next character of input added
        string newPrefix = prefix + str[i];

        // k is decreased, because we have added a new character
        PrintAllKLengthPermRec(str, newPrefix, n, k - 1, operators);
    }
}
//

static BigInteger GetSumOfEquations(List<Equation> equations, string operatorsToUse)
{
    BigInteger sum = 0;

    foreach (Equation equation in equations)
    {
        BigInteger tempResult = equation.Numbers.First();
        List<string> operators = [];

        PrintAllKLengthPerm(operatorsToUse, equation.Numbers.Count - 1, operators);

        for (int i = 0; i < operators.Count; i++)
        {
            string currentOperators = operators[i];
            tempResult = equation.Numbers.First();
            for (int j = 1; j < equation.Numbers.Count; j++)
            {
                if (currentOperators[j - 1].Equals('*'))
                {
                    tempResult *= equation.Numbers[j];
                }
                
                else if (currentOperators[j - 1].Equals('+'))
                {
                    tempResult += equation.Numbers[j];
                }

                else if (currentOperators[j - 1].Equals('|'))
                {
                    tempResult = BigInteger.Parse(tempResult.ToString() + equation.Numbers[j].ToString());
                }
            }

            if (tempResult == equation.Result)
            {
                sum += tempResult;
                break;
            }
        }
    }

    return sum;
}

BigInteger sum = GetSumOfEquations(equations, "*+");


Console.WriteLine();
Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(7, 1, (double)sum));

// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

BigInteger sum2 = GetSumOfEquations(equations, "*+|");

Console.WriteLine("Sum: " + sum2);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(7, 2, (double)sum2));