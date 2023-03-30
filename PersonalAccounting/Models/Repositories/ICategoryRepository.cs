namespace PersonalAccounting.Models.Repositories
{
    public interface ICategoryRepository
    {
        Category Get(int id);
        IEnumerable<Category> GetAll();
        Category Create(Category category);
        Category Update(Category category);
        Category Delete(int id);
    }
}
