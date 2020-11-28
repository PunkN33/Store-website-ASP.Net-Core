using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftApp.Data.Repositories;
using CraftApp.Models;
using CraftApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CraftApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ICraftRepository _allCrafts;
        private readonly EFCart _EFCart;

        public ShoppingCartController(ICraftRepository allCrafts, EFCart EFCart)
        {
            _allCrafts = allCrafts;
            _EFCart = EFCart;
        }
        public ViewResult Index()
        {
            var items = _EFCart.getItems();
            _EFCart.shopItems = items;
            var cartModel = new ShoppingCartViewModel
            {
                efCart = _EFCart
            };
            return View(cartModel);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _allCrafts.Crafts.FirstOrDefault(e => e.Id == id);
            if (item != null)
            {
                _EFCart.AddToCraft(item);
            }
            return RedirectToAction("Index");
        }
    }
}
