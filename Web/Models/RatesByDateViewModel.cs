using Application;

namespace Web.Models
{
    public class RatesByDateViewModel
    {
        public DateTime SelectedDate { get; set; }
        public List<СurrencyRateModel>? Rates { get; set; }
    }
}
