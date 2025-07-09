using DuplicateChecker;

string[] paths;
if (args.Length <= 0)
{
    Console.WriteLine("Enter a directory path.");
    Console.WriteLine(@"For more than 1 directories, please use 'DuplicateChecker.exe ""C:\Path To\Dir1\"" D:\Path\To\Dir2'");
    Console.Write(" > ");
    paths = [Console.ReadLine() ?? ""];
}
else paths = args;

var Checker = new Checker(paths);

Console.Write("Started");

Checker.Check();

Console.Write("-Finished");
Console.WriteLine($"-{Checker.Duplicates.Count} Matches");
Console.WriteLine();

foreach (var item in Checker.Duplicates)
{
    Console.WriteLine(BitConverter.ToString(item.Hash));

    foreach (var i in item.Files)
        Console.WriteLine($" > {i.FullName}");

    Console.WriteLine();
}

Console.Write("Save result? (Y/n) > ");
var a = Console.ReadLine() ?? "Y";
if (!"Nn".Any(a.Contains))
    Checker.SaveResult();