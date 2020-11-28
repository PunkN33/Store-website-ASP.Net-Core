using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftApp.Data.Repositories;
using CraftApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CraftApp.Controllers
{
    public class HomeController : Controller
    {
        private ICraftRepository _allCrafts;       

        public HomeController(ICraftRepository allCrafts)
        {
            _allCrafts = allCrafts;            
        }
        public IActionResult Index()
        {
            var mainCrafts = new HomeViewModel
            {
                FavoriteCrafts = _allCrafts.FavoriteCrafts
            };
            return View(mainCrafts);
        }
    }
}
