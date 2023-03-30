namespace PersonalAccounting.Models
{
    public class CategoryTransaction
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TransactionId { get; set; }
    }
}
