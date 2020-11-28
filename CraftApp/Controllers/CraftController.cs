using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftApp.Data.Repositories;
using CraftApp.Models;
using CraftApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CraftApp.Controllers
{
    public class CraftController : Controller
    {        

        private readonly ICraftRepository _allCrafts;
        private readonly ICategoryRepository _allCategory;

        public CraftController(ICraftRepository allCrafts, ICategoryRepository allCategory)
        {
            _allCrafts = allCrafts;
            _allCategory = allCategory;
        }
        [Route("Craft/List")]
        [Route("Craft/List/{category}")]
        public ViewResult List(string category)
        {            
            string _category = category;
            IEnumerable<Craft> craft = null;
            string currentCategory = " ";

            if (string.IsNullOrEmpty(category))
            {
                craft = _allCrafts.Crafts.OrderBy(e => e.Id).ToList();
            }
            else
            {
                if (string.Equals("Plant", category, StringComparison.OrdinalIgnoreCase))
                {
                    craft = _allCrafts.Crafts.Where(e => e.Category.Name.Equals("Растения")).OrderBy(e => e.Id);
                    currentCategory = "Растения";
                }
                else if (string.Equals("Ornament", category, StringComparison.OrdinalIgnoreCase))
                {
                    craft = _allCrafts.Crafts.Where(e => e.Category.Name.Equals("Украшения")).OrderBy(e => e.Id);
                    currentCategory = "Украшения";
                }
                else if (string.Equals("Wood", category, StringComparison.OrdinalIgnoreCase))
                {
                    craft = _allCrafts.Crafts.Where(e => e.Category.Name.Equals("Деревянный дизайн")).OrderBy(e => e.Id);
                    currentCategory = "Деревянный дизайн";
                }
            }

            var craftObj = new CraftViewModel
            {
                getAllCrafts = craft,
                currentCategory = currentCategory
            };

            //ViewBag.Title = "Страница с товарами";

            return View(craftObj);
        }

       
    }
}
