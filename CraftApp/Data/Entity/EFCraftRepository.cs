using CraftApp.Data.Repositories;
using CraftApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.Data.Entity
{
    public class EFCraftRepository : ICraftRepository
    {
        private CraftDbContext _context;

        public EFCraftRepository(CraftDbContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Craft> Crafts => _context.Crafts.Include(e => e.Category);

        public IEnumerable<Craft> FavoriteCrafts => _context.Crafts.Where(c => c.IsFavorite).Include(e => e.Category);

        public Craft getCraft(int craftId) => _context.Crafts.FirstOrDefault(c => c.Id == craftId);





    }
}
