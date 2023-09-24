using JobInterviewTestConsole.Commands;

namespace JobInterviewTestConsole.Domain;

internal record Error(ErrorCode Code, string Message);
