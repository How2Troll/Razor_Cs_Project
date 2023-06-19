using Microsoft.EntityFrameworkCore;
using RazorPagesCurrency.Data;

namespace RazorPagesCurrency.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesCurrencyContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesCurrencyContext>>()))
        {
            if (context == null || context.Currency == null)
            {
                throw new ArgumentNullException("Null RazorPagesCurrencyContext");
            }

            // Look for any currencies.
             if (context.Currency.Any())
             {
                 return;   // DB has been seeded
             }

            var lastThirtyDaysRate = new List<LastThirtyDaysRate>();
            var lastThirtyDaysRateExample = new LastThirtyDaysRate
            {
            dateTime = DateTime.Today.AddDays(1),
            ExchangeRateElement = 1.25M
            };
            lastThirtyDaysRate.Add(lastThirtyDaysRateExample);

            lastThirtyDaysRateExample = new LastThirtyDaysRate
            {
            dateTime = DateTime.Today.AddDays(2),
            ExchangeRateElement = 1.28M
            };
            lastThirtyDaysRate.Add(lastThirtyDaysRateExample);

            lastThirtyDaysRateExample = new LastThirtyDaysRate
            {
            dateTime = DateTime.Now,
            ExchangeRateElement = 1.23M
            };
            lastThirtyDaysRate.Add(lastThirtyDaysRateExample);


            context.Currency.AddRange(
                new Currency
                {
                    Name = "USD",
                    ExchangeRate = 1.0M,
                    ListExchange = lastThirtyDaysRate
                },

                new Currency
                {
                    Name = "PLN",
                    ExchangeRate = 0.24M
                },

                new Currency
                {
                    Name = "EUR",
                    ExchangeRate = 1.08M
                }
            );


            context.SaveChanges();
        }
    }

    public static async Task UpdateExchangeRate(IServiceProvider serviceProvider, List<LastThirtyDaysRate> lastThirtyDaysRate)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<RazorPagesCurrencyContext>();

            var currency = context.Currency.FirstOrDefault(c => c.Name == "USD");
            if (currency != null)
            {
                currency.ListExchange = lastThirtyDaysRate;
                await context.SaveChangesAsync();
            }
        }
    }


}