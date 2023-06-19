using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesCurrency.Models;

public class LastThirtyDaysRate
{
    [Key]
    public int Id { get; set; }
    public decimal ExchangeRateElement {get; set;}
    public  DateTime dateTime {get; set;}

    public override string ToString()
    {
        return $"{dateTime}: {ExchangeRateElement}";
    }
}