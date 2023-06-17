using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Currency == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any currencies.
             if (context.Currency.Any())
             {
                 return;   // DB has been seeded
             }

            context.Currency.AddRange(
                new Currency
                {
                    Name = "USD",
                    ExchangeRate = 1.0M
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
}