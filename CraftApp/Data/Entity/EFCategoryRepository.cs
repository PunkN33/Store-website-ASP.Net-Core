using CraftApp.Data.Repositories;
using CraftApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.Data.Entity
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private CraftDbContext _context;

        public EFCategoryRepository(CraftDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Category> Categories => _context.Categories;
        
    }
}
