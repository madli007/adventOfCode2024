// See https://aka.ms/new-console-template for more information


Console.WriteLine("Naloga 2");

string[] lines = Helper.Helper.GetAllInputsFromTxt(2, false);

// parse data
List<List<int>> reports = [];

foreach (string line in lines)
{
    string[] numbersSplit = line.Split(" ");
    List<int> levels = [];

    foreach (string level in numbersSplit)
    {
        levels.Add(int.Parse(level));
    }

    reports.Add(levels);
}

static bool IsReportSafe(List<int> report, bool tolerateSingleBadLevel = false)
{
    bool isReportSafe = true;

    if (report.Count == 0)
    {
        return false;
    }

    int mistakes = 0;

    startOver:
    bool? smaller = null;
    bool? bigger = null;
    int currentValue = report[0];
    for (int i = 1; i < report.Count; i++)
    {
        if (smaller == null && bigger == null)
        {
            if (report[i] < currentValue && currentValue - report[i] <= 3)
            {
                smaller = true;
                currentValue = report[i];
            }
            else if (report[i] > currentValue && report[i] - currentValue <= 3)
            {
                bigger = true;
                currentValue = report[i];
            }
            else
            {
                isReportSafe = false;
                mistakes++;

                if (tolerateSingleBadLevel)
                {
                    if (mistakes > 1)
                    {
                        break;
                    }
                    else
                    {
                        smaller = null;
                        bigger = null;
                        isReportSafe = true;
                        report.RemoveAt(i);
                        goto startOver;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        else if (smaller == true)
        {
            if (report[i] < currentValue && currentValue - report[i] <= 3)
            {
                currentValue = report[i];
            }
            else
            {
                isReportSafe = false;

                mistakes++;

                if (tolerateSingleBadLevel)
                {
                    if (mistakes > 1)
                    {
                        break;
                    }
                    else
                    {
                        smaller = null;
                        bigger = null;
                        isReportSafe = true;
                        report.RemoveAt(i);
                        goto startOver;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        else if (bigger == true)
        {
            if (report[i] > currentValue && report[i] - currentValue <= 3)
            {
                currentValue = report[i];
            }
            else
            {
                isReportSafe = false;

                mistakes++;

                if (tolerateSingleBadLevel)
                {
                    if (mistakes > 1)
                    {
                        break;
                    }
                    else
                    {
                        smaller = null;
                        bigger = null;
                        isReportSafe = true;
                        report.RemoveAt(i - 1);
                        goto startOver;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }

    return isReportSafe;
}

int sum = 0;

foreach (List<int> report in reports)
{
    bool isReportSafe = IsReportSafe(report);

    //Console.WriteLine(isReportSafe);

    if (isReportSafe == true)
    {
        sum++;
    }
}

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(2, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;

foreach (List<int> report in reports)
{
    bool isReportSafe = IsReportSafe(report, true);

    if (isReportSafe == false)
    {
        foreach (int i in report)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine(" => " + isReportSafe);
    }


    if (isReportSafe == true)
    {
        sum2++;
    }
}

Console.WriteLine("Sum: " + sum2);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(2, 2, sum2));