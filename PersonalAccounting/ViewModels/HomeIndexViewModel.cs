using PersonalAccounting.DataAccess;
using PersonalAccounting.Models;
using PersonalAccounting.Models.Repositories;

namespace PersonalAccounting.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
        public double Sum { get; set; }
        public IEnumerable<CategoryTransaction>? CategoryTransactions { get; set; }
        public IEnumerable<Category>? Categories { get; set; }   
    }
}
