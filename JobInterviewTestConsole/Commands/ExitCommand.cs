using JobInterviewTestConsole.Domain;

namespace JobInterviewTestConsole.Commands;

internal class ExitCommand : ICommand
{
    public CommandResult Execute()
    {
        return new CommandResult(new Error(ErrorCode.Exit, "Exit command executed"));
    }
}
