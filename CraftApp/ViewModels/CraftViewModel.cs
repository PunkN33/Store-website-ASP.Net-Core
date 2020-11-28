using CraftApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.ViewModels
{
    public class CraftViewModel
    {
        public IEnumerable<Craft> getAllCrafts { get; set; }
        public string currentCategory { get; set; }
    }
}
