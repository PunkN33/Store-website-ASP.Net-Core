using CraftApp.Data.Repositories;
using CraftApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.Data.Entity
{
    public class EFOrder : IOrderRepository
    {
        private readonly CraftDbContext _context;
        private readonly EFCart _efCart;
        public EFOrder(CraftDbContext context, EFCart efCart)
        {
            _context = context;
            _efCart = efCart;
        }      
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();

            var items = _efCart.shopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CraftId = el.Craft.Id,
                    OrderId = order.Id,
                    Price = el.Craft.Price
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }
    }
}
