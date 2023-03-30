namespace PersonalAccounting.Models.Repositories
{
    public interface ICategoryTransactionRepository
    {
        IEnumerable<CategoryTransaction> GetAll();
        CategoryTransaction Create(CategoryTransaction categoryTransaction);
        string GetCategoryNameByTransactionId(int id);
    }
}
