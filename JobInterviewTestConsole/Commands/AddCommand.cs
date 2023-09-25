using JobInterviewTestConsole.Domain;
using JobInterviewTestConsole.Infrastructure;

namespace JobInterviewTestConsole.Commands;

internal class AddCommand : ICommand
{
    private readonly ITransactionRepository _transactionRepository;

    public AddCommand(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public string Name => Constants.Add;

    public CommandResult Execute()
    {
        Console.Write("Enter Id: ");
        var value = Console.ReadLine();
        if (!int.TryParse(value, out var id))
            return new CommandResult(new Error(ErrorCode.WrongInput, $"Wrong Id value inputted - '{value}'"));

        if (_transactionRepository.Contains(id))
            return new CommandResult(new Error(ErrorCode.AlreadyExists, "Inputted Id already exists"));

        Console.Write("Enter Date: ");
        value = Console.ReadLine();
        if (!DateTime.TryParse(value, out DateTime transactionDate))
            return new CommandResult(new Error(ErrorCode.WrongInput, $"Wrong Date value inputted - '{value}'"));

        Console.Write("Enter Amount: ");
        value = Console.ReadLine();
        if (!decimal.TryParse(value, out var amount))
            return new CommandResult(new Error(ErrorCode.WrongInput, $"Wrong Amount value inputted - '{value}'"));

        _transactionRepository.Add(new Transaction(id, transactionDate, amount));

        return CommandResult.Success;
    }
}
