using JobInterviewTestConsole.Domain;

namespace JobInterviewTestConsole.Infrastructure;

internal interface ITransactionRepository
{
    Transaction Resolve(int id);

    bool Contains(int id);

    void Add(Transaction transaction);
}
