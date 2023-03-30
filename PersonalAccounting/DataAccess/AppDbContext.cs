using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Models;

namespace PersonalAccounting.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTransactionPivot> CategoryTransactionPivot { get; set; }
        public DbSet<CategoryTransaction> CategoryTransaction { get; set; }

        public string GetCategoryNameByTransactionId(int id)
        {
            int categoryId = CategoryTransaction.Where(x => x.TransactionId == id).Select(y => y.CategoryId).FirstOrDefault();
            return Categories.Where(x => x.Id == categoryId).Select(y => y.Name).FirstOrDefault();
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }*/
    }
}
