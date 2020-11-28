using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftApp.Data;
using CraftApp.Data.Repositories;
using CraftApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CraftApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orders;
        private readonly EFCart _efCart;

        public OrderController(IOrderRepository orders, EFCart efCart)
        {            
            _orders = orders;
            _efCart = efCart;
        }

        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _efCart.shopItems = _efCart.getItems();
            if(_efCart.shopItems.Count == 0)
            {
                ModelState.AddModelError("", "Нет товаров в корзине");
            }
            if(ModelState.IsValid)
            {
                _orders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
