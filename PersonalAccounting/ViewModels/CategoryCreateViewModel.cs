using PersonalAccounting.Models;
using System.ComponentModel.DataAnnotations;

namespace PersonalAccounting.ViewModels
{
    public class CategoryCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        public ActionTypes Type { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
