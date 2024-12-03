// See https://aka.ms/new-console-template for more information


using System.Text.RegularExpressions;

Console.WriteLine("Naloga 3");

string[] lines = Helper.Helper.GetAllInputsFromTxt(3, false);

Regex regex = new("mul\\([0-9]{1,3},[0-9]{1,3}\\)");
List<MatchCollection?> matches = [];

// parse
foreach (string line in lines)
{
    MatchCollection matchCollection = regex.Matches(line);
    matches.Add(matchCollection);

    foreach (Match match in matchCollection)
    {
        Console.WriteLine(match.Value);
    }
}

int sum = 0;
if (matches != null)
{
    foreach (MatchCollection matchCollection in matches)
    {
        foreach (Match match in matchCollection)
        {
            int number1 = int.Parse(match.Value.Split(',')[0].Replace("mul(", ""));
            int number2 = int.Parse(match.Value.Split(',')[1].Replace(")", ""));

            sum += number1 * number2;
        }
    }
}


Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(3, 1, sum));