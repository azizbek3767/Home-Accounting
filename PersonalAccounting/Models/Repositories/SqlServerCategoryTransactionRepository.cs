using Microsoft.EntityFrameworkCore;
using PersonalAccounting.DataAccess;

namespace PersonalAccounting.Models.Repositories
{
    public class SqlServerCategoryTransactionRepository : ICategoryTransactionRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICategoryRepository _categoryRepository;

        public SqlServerCategoryTransactionRepository(AppDbContext dbContext, ICategoryRepository categoryRepository)
        {
            _dbContext = dbContext;
            _categoryRepository = categoryRepository;
        }
        public CategoryTransaction Create(CategoryTransaction categoryTransaction)
        {
            _dbContext.CategoryTransaction.Add(categoryTransaction);
            _dbContext.SaveChanges();
            return categoryTransaction;
        }

        public IEnumerable<CategoryTransaction> GetAll()
        {
            return _dbContext.CategoryTransaction;
        }

        public string GetCategoryNameByTransactionId(int id)
        {
            int categoryId = _dbContext.CategoryTransaction.Where(x => x.TransactionId == id).Select(y => y.CategoryId).FirstOrDefault();
            return _dbContext.Categories.Where(x => x.Id == categoryId).Select(y => y.Name).FirstOrDefault();
        }
    }
}
