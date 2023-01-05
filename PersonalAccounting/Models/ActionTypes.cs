using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PersonalAccounting.Models
{
    public enum ActionTypes
    {
        [Description("Приход")]
        [Display(Name = "Приход")]
        Income,
        [Description("Расход")]
        [Display(Name = "Расход")]
        Expense,
    }
}
