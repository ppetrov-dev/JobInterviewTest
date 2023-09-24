using System.Diagnostics.CodeAnalysis;

namespace JobInterviewTestConsole.Domain;

internal record CommandResult
{
    public static readonly CommandResult Success = new();

    [MemberNotNullWhen(false, nameof(Error))]
    public bool Succeed { get; }

    public Error? Error { get; }

    private CommandResult()
    {
        Succeed = true;
    }

    public CommandResult(Error? error)
    {
        Succeed = false;
        Error = error;
    }
}
