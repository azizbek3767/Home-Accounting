namespace PersonalAccounting.Models.Repositories
{
    public interface ITransactionRepository
    {
        Transaction Get(int id);
        IEnumerable<Transaction> GetAll();
        Transaction Create(Transaction transaction);
        Transaction Update(Transaction transaction);
        Transaction Delete(int id);
    }
}
