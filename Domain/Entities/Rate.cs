using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Rate
    {
        [Key]
        public int RateId { get; set; }
        [ForeignKey("Currency")]
        [Required]
        public int CurrencyId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public short Nominal { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        [Required]
        public decimal Value { get; set; }

        public Currency Currency { get; set; }
    }
}
