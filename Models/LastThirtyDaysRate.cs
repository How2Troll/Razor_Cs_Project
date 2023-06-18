using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesCurrency.Models;

public class LastThirtyDaysRate
{
    public decimal ExchangeRate {get; set;}
    public  DateTime dateTime {get; set;}

    public override string ToString()
    {
        return $"{dateTime}: {ExchangeRate}";
    }
}