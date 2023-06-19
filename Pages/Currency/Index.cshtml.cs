using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCurrency.Data;
using RazorPagesCurrency.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesCurrency.Pages_Currency
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCurrency.Data.RazorPagesCurrencyContext _context;

        public IndexModel(RazorPagesCurrency.Data.RazorPagesCurrencyContext context)
        {
            _context = context;
        }

        public IList<Currency> Currency { get;set; }  = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CurrencyGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Currency
                                            orderby m.Name
                                            select m.Name;

            var currencies = from m in _context.Currency
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                currencies = currencies.Where(s => s.Name.Contains(SearchString));
            }

            Currency = await currencies.ToListAsync();
        }
    }
}
