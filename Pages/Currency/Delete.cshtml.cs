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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesCurrency.Data.RazorPagesCurrencyContext _context;

        public DeleteModel(RazorPagesCurrency.Data.RazorPagesCurrencyContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Currency == null)
            {
                return NotFound();
            }
            var currency = await _context.Currency.FindAsync(id);

            if (currency != null)
            {
                Currency = currency;
                _context.Currency.Remove(Currency);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
