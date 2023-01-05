using System.ComponentModel;

namespace PersonalAccounting.Models
{
    public enum OutcomeTypes
    {
        [Description("Продукты питания")] Grocery,
        [Description("Транспорт")] Transport,
        [Description("Мобильная связь")] MobileConnection,
        [Description("Интернет")] Internet,
        [Description("Развлечения")] Entertainment,
        [Description("Другое")] OtherIncomeTypes,
    }
}
