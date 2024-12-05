// See https://aka.ms/new-console-template for more information

using Day_5;
using System.Linq;

Console.WriteLine("Naloga 5");
Console.WriteLine();

string[] lines = Helper.Helper.GetAllInputsFromTxt(5, false);

List<Rule> rules = [];
List<string> updates = [];

foreach (string line in lines)
{
    if (line.Contains('|'))
    {
        string[] split = line.Split('|');
        int page1 = int.Parse(split[0]);
        int page2 = int.Parse(split[1]);

        rules.Add(new Rule(page1, page2));
    }
    else if (line.Contains(','))
    {
        updates.Add(line);
    }
}

ILookup<int, Rule> rulesLookup = rules.ToLookup(x => x.Page1);

// izpis
foreach (IGrouping<int, Rule> packageGroup in rulesLookup)
{
    Console.WriteLine(packageGroup.Key);
    foreach (Rule r in packageGroup)
    {
        Console.WriteLine("    {0}", r.Page2);
    }
}

int sum = 0;

foreach (string update in updates)
{
    string[] split = update.Split(",");

    int i = 0;
    bool ok = true;

    foreach (string page in split)
    {
        int pageNr = int.Parse(page);
        var rulesForPage = rulesLookup[pageNr];

        foreach (Rule r in rulesForPage)
        {
            int findPages = split.ToList().FindIndex(x => x.Equals(r.Page2.ToString()));

            if (findPages != -1)
            {
                if (findPages < i)
                {
                    ok = false;
                }
            }
        }

        i++;
    }

    if (ok)
    {
        int middleNumber = int.Parse(split[(split.Length - 1) / 2]);
        sum += middleNumber;
    }

    Console.WriteLine(ok);
}

Console.WriteLine();
Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(5, 1, sum));