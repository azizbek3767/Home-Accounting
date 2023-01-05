using System.ComponentModel;

namespace PersonalAccounting.Models
{
    public enum IncomeTypes
    {
        [Description("Заработная плата")] Salary,
        [Description("Дохода с сдачи в аренду недвижимости")] RentIncome,
        [Description("Иные доходы")] OtherIncomeTypes,

    }
}
