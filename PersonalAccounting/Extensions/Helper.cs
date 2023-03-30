using PersonalAccounting.DataAccess;
using PersonalAccounting.Models;
using PersonalAccounting.Models.Repositories;

namespace PersonalAccounting.Extensions
{
    public class Helper
    {
        private readonly AppDbContext _appDbContext;

        public Helper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public string GetCategoryNameByTransactionId(int id)
        {
            int categoryId = _appDbContext.CategoryTransaction.Where(x => x.TransactionId == id).Select(y => y.CategoryId).FirstOrDefault();
            return _appDbContext.Categories.Where(x => x.Id == categoryId).Select(y => y.Name).FirstOrDefault();
        }
    }
}
