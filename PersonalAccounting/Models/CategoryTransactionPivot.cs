using Microsoft.EntityFrameworkCore;

namespace PersonalAccounting.Models
{
    [Keyless]
    public class CategoryTransactionPivot
    {
        public int CategoryId { get; set; }
        public int TransactionId { get; set; }
    }
}
