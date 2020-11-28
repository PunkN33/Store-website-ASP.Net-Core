using CraftApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.Data.Repositories
{
    public interface ICraftRepository
    {
        IEnumerable<Craft> Crafts { get; }
        IEnumerable<Craft> FavoriteCrafts { get; }
        Craft getCraft(int craftId);
    }
}
