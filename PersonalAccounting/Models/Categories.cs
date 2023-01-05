using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PersonalAccounting.Models
{
    public enum Categories
    {
        [Description("Заработная плата")]
        [Display(Name = "Заработная плата")]
        Salary,
        [Description("Дохода с сдачи в аренду недвижимости")]
        [Display(Name = "Дохода с сдачи в аренду недвижимости")]
        RentIncome,
        [Description("Иные доходы")]
        [Display(Name = "Иные доходы")]
        OtherIncomeTypes,
        [Description("Продукты питания")]
        [Display(Name = "Продукты питания")]
        Grocery,
        [Description("Транспорт")]
        [Display(Name = "Транспорт")]
        Transport,
        [Description("Мобильная связь")]
        [Display(Name = "Мобильная связь")]
        MobileConnection,
        [Description("Интернет")]
        [Display(Name = "Интернет")]
        Internet,
        [Description("Развлечения")]
        [Display(Name = "Развлечения")]
        Entertainment,
        [Description("Другое")]
        [Display(Name = "Другое")]
        OtherExpenseTypes
    }
}
