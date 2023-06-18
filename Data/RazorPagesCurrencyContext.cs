using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesCurrency.Models;

namespace RazorPagesCurrency.Data
{
    public class RazorPagesCurrencyContext : DbContext
    {
        public RazorPagesCurrencyContext (DbContextOptions<RazorPagesCurrencyContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesCurrency.Models.Currency> Currency { get; set; } = default!;
    }
}
