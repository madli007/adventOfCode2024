// See https://aka.ms/new-console-template for more information

static string[] GetAllInputsFromTxt()
{
    string textFile = "input.txt";
    string[] lines = [];

    if (File.Exists(textFile))
    {
        // Read a text file line by line.
        lines = File.ReadAllLines(textFile);
    }

    return lines;
}

//string testInput = "3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3";

string[] lines = GetAllInputsFromTxt();
//string[] lines = testInput.Split("\r\n");

List<int> list1 = [];
List<int> list2 = [];

// priprava podatkov
foreach (string line in lines)
{
    var list = line.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s));
    string stringWithSingleSpace = string.Join(" ", list);
    string[] splitLists = stringWithSingleSpace.Split(" ");

    list1.Add(int.Parse(splitLists[0]));
    list2.Add(int.Parse(splitLists[1]));
}

list1 = [.. list1.OrderBy(s => s)];
list2 = [.. list2.OrderBy(s => s)];


// part 1
int sum = 0;

for (int i = 0; i < list1.Count; i++)
{
    sum += Math.Abs(list1[i] - list2[i]);
}


// izpis
foreach (int number in list2)
{
    Console.WriteLine(number);
}

Console.WriteLine("Naloga 1");
Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);



// part 2
