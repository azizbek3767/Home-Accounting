using System.ComponentModel.DataAnnotations;

namespace PersonalAccounting.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public ActionTypes Type { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
