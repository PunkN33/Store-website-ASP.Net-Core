using CraftApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.Data.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
