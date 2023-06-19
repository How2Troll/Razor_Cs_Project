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

      public Currency Currency { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Currency == null)
            {
                return NotFound();
            }

            var currency = await _context.Currency.FirstOrDefaultAsync(m => m.Id == id);
            if (currency == null)
            {
                return NotFound();
            }
            else 
            {
                Currency = currency;
            }
            return Page();
        }
    }
}
