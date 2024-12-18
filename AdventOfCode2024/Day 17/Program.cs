// See https://aka.ms/new-console-template for more information

Console.WriteLine("Naloga 17");

string[] lines = Helper.Helper.GetAllInputsFromTxt(17, true);

int sum = 0;

Console.WriteLine("Part 1");
Console.WriteLine("Sum: " + sum);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(17, 1, sum));


// part 2
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Part 2");

int sum2 = 0;

Console.WriteLine("Sum: " + sum2);
Console.WriteLine(Helper.Helper.IsMyTestResultCorrect(17, 2, sum2));