﻿using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class CheeseProvider
    {
        private readonly DatabaseContext _context;

        public CheeseProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Cheese>> GetCheesesAsync()
        {
            return await _context.Cheeses.OrderBy(CheeseProvider => CheeseProvider.Name).ToListAsync();
        }

        public Cheese? GetCheese(int id)
        {
            return _context.Cheeses.Find(id);
        }
    }
}
