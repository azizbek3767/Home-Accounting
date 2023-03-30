using System.ComponentModel.DataAnnotations;

namespace PersonalAccounting.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateTime { get; set; }

        [Required]
        public ActionTypes Type { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [DataType(DataType.Text)]
        public string Comment { get; set; }

        public double Sum { get; set; }
    }
}
