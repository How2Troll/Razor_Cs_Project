using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages_Movies
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public DeleteModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
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
