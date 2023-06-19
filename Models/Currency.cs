using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace RazorPagesCurrency.Models;

public class Currency
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Name { get; set; } = string.Empty;

    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(4, 6)")]
    [DisplayFormat(DataFormatString = "${0:N6}")]
    public decimal ExchangeRate { get; set; }

    public List<LastThirtyDaysRate> ListExchange {get; set;}

}