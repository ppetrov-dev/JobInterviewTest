using JobInterviewTestConsole.Domain;

namespace JobInterviewTestConsole.Infrastructure;

internal interface ITransactionRepository
{
    Transaction Get(int id);

    bool Contains(int id);

    void Add(Transaction transaction);
}
