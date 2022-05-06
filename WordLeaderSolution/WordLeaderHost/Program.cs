using WordLadderHost;
using WordLadderBusiness.Validators;
using WordLadderHost.Data;

var startWord = string.Empty;
var endWord = string.Empty;
var dictionaryPath = string.Empty;
var resultPath = string.Empty;

foreach(var arg in args)
{
    var input = string.Empty;
    switch (arg[..2].ToUpper())
    {
        case "-S":
            input = arg[3..];
            if (ArgumentsValidator.IsWordValid(input, "-S"))
            {
                startWord = input;
            }            
            break;
        case "-E":
            input = arg[3..];
            if (ArgumentsValidator.IsWordValid(input, "-E"))
            {
                endWord = input;
            }
            break;
        case "-D":
            input = arg[3..];
            if (ArgumentsValidator.IsFilePathValid(input, "-D"))
            {
                dictionaryPath = input;
            }
            break;
        case "-O":
            input = arg[3..];
            if (ArgumentsValidator.IsDirectoryPathValid(input, "-O"))
            {
                resultPath = input;
            }
            break;
        case "-H":
            Console.WriteLine("----- Word Ladder Help -----");
            Console.WriteLine("Acceptable arguments:");
            Console.WriteLine("  -S:'value' -> The start word");
            Console.WriteLine("  -E:'value' -> The end word");
            Console.WriteLine("  -D:'value' -> The dictionary file path");
            Console.WriteLine("  -O:'value' -> The output folder");
            Console.WriteLine("  -H -> The help menu");
            return;
        default:
            break;
    }
}

Console.WriteLine("----- Welcome to Word Leader application! -----");

var startWordIsSet = !string.IsNullOrEmpty(startWord);

while(startWordIsSet == false)
{
    Console.WriteLine("Start Word:");
    var input = Console.ReadLine();
    startWordIsSet = ArgumentsValidator.IsWordValid(input);
    startWord = input;
}


var endWordIsSet = !string.IsNullOrEmpty(endWord);

while (endWordIsSet == false)
{
    Console.WriteLine("End Word:");
    var input = Console.ReadLine();
    endWordIsSet = ArgumentsValidator.IsWordValid(input);
    endWord = input;
}

var dictionaryPathIsSet = !string.IsNullOrEmpty(dictionaryPath);

while (dictionaryPathIsSet == false)
{
    Console.WriteLine("Dictionary Path:");
    var input = Console.ReadLine();
    dictionaryPathIsSet = ArgumentsValidator.IsFilePathValid(input);
    dictionaryPath = input;
}

var resultPathIsSet = !string.IsNullOrEmpty(resultPath);

while (resultPathIsSet == false)
{
    Console.WriteLine("Result Path:");
    var input = Console.ReadLine();
    resultPathIsSet = ArgumentsValidator.IsDirectoryPathValid(input);
    resultPath = input;
}

Console.Clear();
Console.WriteLine("----- Word Ladder - Inputs Summary: -----");
Console.WriteLine("Start word: " + startWord);
Console.WriteLine("End word: " + endWord);
Console.WriteLine("Dictionary path: " + dictionaryPath);
Console.WriteLine("Result path: " + resultPath);
Console.WriteLine();
Console.WriteLine("Press any key to start execution!");
Console.ReadKey();

if (startWord != null && endWord != null && dictionaryPath != null && resultPath != null)
{
    var argumentsDto = new ArgumentsDto(startWord, endWord, dictionaryPath, resultPath, 4);
    await WordLadderScopedExecution.Execute(args, argumentsDto);
}
else
{
    Console.WriteLine("ERROR: Inputs are missing!");
}