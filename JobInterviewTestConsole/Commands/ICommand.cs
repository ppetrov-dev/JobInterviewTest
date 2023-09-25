using JobInterviewTestConsole.Domain;

namespace JobInterviewTestConsole.Commands;

internal interface ICommand
{
    CommandResult Execute();
}
