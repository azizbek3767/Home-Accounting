using PersonalAccounting.Models;

namespace PersonalAccounting.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
