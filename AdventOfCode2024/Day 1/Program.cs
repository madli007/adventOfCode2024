// See https://aka.ms/new-console-template for more information

Console.WriteLine("Naloga 1");

string[] lines = Helper.Helper.GetAllInputsFromTxt(1, false);

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

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(1, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;
for (int i = 0; i < list1.Count; i++)
{
    int numberOfRepetitions = list2.FindAll(x => x == list1[i]).Count;
    sum2 += list1[i] * numberOfRepetitions;
}

Console.WriteLine("Sum: " + sum2);
//Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(1, 2, sum2));