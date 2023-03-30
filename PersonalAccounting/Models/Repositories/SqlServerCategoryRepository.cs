using PersonalAccounting.DataAccess;

namespace PersonalAccounting.Models.Repositories
{
    public class SqlServerCategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public SqlServerCategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Category Create(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category;
        }

        public Category Delete(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
            return category;
        }

        public Category Get(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories;
        }

        public Category Update(Category updateCategory)
        {
            if (updateCategory != null)
            {
                var category = _dbContext.Categories.Attach(updateCategory);
                category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            return updateCategory;
        }
    }
}
