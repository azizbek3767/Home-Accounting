using PersonalAccounting.DataAccess;

namespace PersonalAccounting.Models.Repositories
{
    public class SqlServerTransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _dbContext;

        public SqlServerTransactionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Transaction Create(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
            return transaction;
        }

        public Transaction Delete(int id)
        {
            var transaction = _dbContext.Transactions.Find(id);
            if (transaction != null)
            {
                _dbContext.Transactions.Remove(transaction);
                _dbContext.SaveChanges();
            }
            return transaction;
        }

        public Transaction Get(int id)
        {
            return _dbContext.Transactions.Find(id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _dbContext.Transactions;
        }

        public Transaction Update(Transaction updateTransaction)
        {
            if (updateTransaction != null)
            {
                var transaction = _dbContext.Transactions.Attach(updateTransaction);
                transaction.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            return updateTransaction;
        }
    }
}
