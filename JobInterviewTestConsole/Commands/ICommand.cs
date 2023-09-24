using JobInterviewTestConsole.Domain;

namespace JobInterviewTestConsole.Commands;

internal interface ICommand
{
    string Name { get; }
    CommandResult Execute();
}
