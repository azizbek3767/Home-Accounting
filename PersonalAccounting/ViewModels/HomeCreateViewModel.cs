using PersonalAccounting.Models;
using System.ComponentModel.DataAnnotations;

namespace PersonalAccounting.ViewModels
{
    public class HomeCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateTime { get; set; } = System.DateTime.Now;

        [Required]
        public ActionTypes Type { get; set; }

        [Required]
        public Categories Category { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Comment { get; set; }
    }
}
