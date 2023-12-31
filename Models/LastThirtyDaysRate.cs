using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesCurrency.Models;

 public class LastThirtyDaysRate
    {
        [Key]
        public int Id { get; set; }

        public decimal ExchangeRateElement { get; set; }
        public DateTime DateTime { get; set; }

        public int CurrencyId { get; set; } // Foreign key property

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; } // Navigation property

        public override string ToString()
        {
            return $"{DateTime}: {ExchangeRateElement}";
        }
    }
