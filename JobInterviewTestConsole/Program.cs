using JobInterviewTestConsole.Commands;
using JobInterviewTestConsole.Infrastructure;

var transactionRepository = new TransactionRepository();
var allCommandsDictionary = new Dictionary<string, ICommand>
{
    { Constants.Add, new AddCommand(transactionRepository) },
    { Constants.Get, new GetCommand(transactionRepository) },
    { Constants.Exit, new ExitCommand() },
};

try
{
    while (true)
    {
        Console.WriteLine("Here are 'add', 'get' or 'exit' commands available, please proceed: ");
        var value = Console.ReadLine()?.ToLower() ?? string.Empty;

        if (!allCommandsDictionary.ContainsKey(value))
        {
            Console.WriteLine("Unknown command. Please, try again.");
            continue;
        }

        var commandResult = allCommandsDictionary[value].Execute();

        if (commandResult.Succeed)
        {
            Console.WriteLine("[OK]");
            continue;
        }
        
        if (commandResult.Error.Code == ErrorCode.Exit)
            break;

        Console.WriteLine($"[NOT OK] Error happened: {commandResult.Error.Message}. Please, try again. ");
    }
}
catch (Exception exception)
{
    Console.WriteLine($"Unhandled exception happened: {exception.Message}");
}
