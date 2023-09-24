namespace JobInterviewTestConsole.Domain;

public class TransactionBuilder
{
    public int Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }

    public Transaction Build() => new(Id, TransactionDate, Amount);
}
