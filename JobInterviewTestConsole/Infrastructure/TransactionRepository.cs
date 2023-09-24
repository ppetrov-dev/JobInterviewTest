using JobInterviewTestConsole.Domain;

namespace JobInterviewTestConsole.Infrastructure;

internal class TransactionRepository : ITransactionRepository
{
    private IDictionary<int, Transaction> _cache = new Dictionary<int, Transaction>();

    public Transaction Resolve(int id) => _cache[id];

    public bool Contains(int id) => _cache.ContainsKey(id);

    public void Add(Transaction transaction) => _cache[transaction.Id] = transaction;
}
