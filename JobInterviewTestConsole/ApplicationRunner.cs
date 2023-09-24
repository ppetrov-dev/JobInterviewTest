using JobInterviewTestConsole.Commands;

namespace JobInterviewTestConsole;

internal class ApplicationRunner : IApplicationRunner
{
    private readonly Dictionary<string, ICommand> _allCommandsDictionary;

    public ApplicationRunner(IEnumerable<ICommand> commands)
    {
        _allCommandsDictionary = commands.ToDictionary(command => command.Name);
    }

    public void Run()
    {
        try
        {
            while (true)
            {
                Console.WriteLine($"The following command available ({string.Join(", ", _allCommandsDictionary.Keys)}), please proceed: ");
                var value = Console.ReadLine()?.ToLower() ?? string.Empty;

                if (!_allCommandsDictionary.ContainsKey(value))
                {
                    Console.WriteLine("Unknown command. Please, try again.");
                    continue;
                }

                var commandResult = _allCommandsDictionary[value].Execute();

                if (commandResult.Succeed)
                    continue;

                if (commandResult.Error.Code == ErrorCode.Exit)
                    break;

                Console.WriteLine($"Error happened: {commandResult.Error.Message}. Please, try again. ");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Unhandled exception happened: {exception.Message}");
        }
    }
}
