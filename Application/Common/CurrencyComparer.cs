using Domain.Entities;

namespace Application.Common
{
    public class CurrencyComparer : IEqualityComparer<Currency>
    {
        public bool Equals(Currency x, Currency y)
        {
            return x.CharCode == y.CharCode;
        }

        public int GetHashCode(Currency obj)
        {
            return obj.CharCode.GetHashCode();
        }
    }
}
