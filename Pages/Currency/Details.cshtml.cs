using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCurrency.Data;
using RazorPagesCurrency.Models;

namespace RazorPagesCurrency.Pages_Currency
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesCurrency.Data.RazorPagesCurrencyContext _context;

        public DetailsModel(RazorPagesCurrency.Data.RazorPagesCurrencyContext context)
        {
            _context = context;
        }

      public Currency Currency { get; set; }

      public List<LastThirtyDaysRate> ListExchange { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Currency = await _context.Currency.FindAsync(id);

            if (Currency == null)
            {
                return NotFound();
            }

            // Fetch the ListExchange based on CurrencyId
            ListExchange = await _context.LastThirtyDaysRates
                .Where(rate => rate.CurrencyId == id)
                .ToListAsync();

            return Page();
        }
    }
}
