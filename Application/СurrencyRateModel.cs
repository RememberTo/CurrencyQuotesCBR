using Microsoft.EntityFrameworkCore.Internal;

namespace Application
{
    public class СurrencyRateModel
    {
        public string CurrencyCharCode { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public short Nominal { get; set; }
    }
}
