using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesCurrency.Data;
using RazorPagesCurrency.Models;

namespace RazorPagesCurrency.Pages_Currencys
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesCurrency.Data.RazorPagesCurrencyContext _context;

        public CreateModel(RazorPagesCurrency.Data.RazorPagesCurrencyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Currency Currency { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Currency == null || Currency == null)
            {
                return Page();
            }

            _context.Currency.Add(Currency);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
