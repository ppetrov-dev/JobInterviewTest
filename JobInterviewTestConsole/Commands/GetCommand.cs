using JobInterviewTestConsole.Domain;
using JobInterviewTestConsole.Infrastructure;
using Newtonsoft.Json;

namespace JobInterviewTestConsole.Commands;

internal class GetCommand : ICommand
{
    private readonly ITransactionRepository _transactionRepository;

    public GetCommand(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public string Name => Constants.Get;

    public CommandResult Execute()
    {
        Console.Write("Enter Id: ");
        var value = Console.ReadLine();
        if (!int.TryParse(value, out var id))
            return new CommandResult(new Error(ErrorCode.WrongInput, $"Wrong Id value inputted - '{value}'"));

        if (!_transactionRepository.Contains(id))
            return new CommandResult(new Error(ErrorCode.DoesNotExist, "Inputted Id does not exist"));

        Console.WriteLine(JsonConvert.SerializeObject(_transactionRepository.Get(id)));

        return CommandResult.Success;
    }
}
