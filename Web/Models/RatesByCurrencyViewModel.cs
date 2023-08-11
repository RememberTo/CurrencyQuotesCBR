using Application;

namespace Web.Models
{
    public class RatesByCurrencyViewModel
    {
        public string? SelectedCurrency { get; set; }
        public List<string>? Currencies { get; set; }
        public List<СurrencyRateModel>? Rates { get; set; } 
    }
}
