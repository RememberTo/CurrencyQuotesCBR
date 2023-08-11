using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string NumCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string CharCode { get; set; }
    }
}
