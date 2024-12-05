// See https://aka.ms/new-console-template for more information

using Day_5;
using System.Numerics;

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

List<List<int>> incorrectlyOrderedUpdates = [];

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
    else
    {
        List<int> list = [];
        foreach (string s in split)
        {
            int nr = int.Parse(s);
            list.Add(nr);
        }
        incorrectlyOrderedUpdates.Add(list);
    }

    Console.WriteLine(ok);
}

Console.WriteLine();
Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(5, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

bool IsFollowingRules(List<int> update)
{
    int i = 0;
    bool ok = true;

    foreach (int pageNr in update)
    {
        var rulesForPage = rulesLookup[pageNr];

        foreach (Rule r in rulesForPage)
        {
            int findPages = update.FindIndex(x => x.Equals(r.Page2));

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

    return ok;
}

static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
{
    if (length == 1) return list.Select(t => new T[] { t });

    return GetPermutations(list, length - 1)
        .SelectMany(t => list.Where(e => !t.Contains(e)),
            (t1, t2) => t1.Concat(new T[] { t2 }));
}

IEnumerable<IEnumerable<int>> resul123t =
    GetPermutations(Enumerable.Range(1, 3), 3);

static long Factorial(int n)
{
    if (n == 0 || n == 1)
        return 1;
    return n * Factorial(n - 1);
}

int sum2 = 0;

foreach (List<int> update in incorrectlyOrderedUpdates)
{
    bool isOk = false;

    // original order
    //foreach (int i in update)
    //{
    //    Console.Write(i + ", ");
    //}

    var result = GetPermutations(update, update.Count);

    //var result = GetPermutations(update, update.Count);
    BigInteger counter = 0;
    BigInteger comboNumber = Factorial(update.Count);

    foreach (IEnumerable<int> combo in result)
    {
        isOk = IsFollowingRules(combo.ToList());
        if (isOk)
        {
            break;
        }

        counter++;

        if (counter % 100000 == 0)
        {
            Console.WriteLine(counter.ToString() + "/" + comboNumber.ToString());
        }
    }

    //List<int> shuffledList = [];
    //shuffledList.AddRange(update);
    //shuffledList.Shuffle();

    //bool isOk = IsFollowingRules(shuffledList);
    //int counter = 0;

    //while (!isOk)
    //{
    //    shuffledList = [];
    //    shuffledList.AddRange(update);
    //    shuffledList.Shuffle();
    //    isOk = IsFollowingRules(shuffledList);
    //    counter++;
    //}


    if (result != null)
    {
        // correct order
        //Console.Write(" => ");
        //foreach (int i in result.ToList()[counter])
        //{
        //    Console.Write(i + ", ");
        //}

        //Console.WriteLine();

        //int middleNumber = result[(result.Count - 1) / 2];
        //sum2 += middleNumber;
    }
}

Console.WriteLine("Sum: " + sum2);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(5, 2, sum2));