﻿using CraftApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Craft> FavoriteCrafts { get; set; }
    }
}
