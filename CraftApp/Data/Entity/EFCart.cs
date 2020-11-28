using CraftApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.Models
{
    //общаяя корзина
    public class EFCart
    {
        private CraftDbContext _context;

        public EFCart(CraftDbContext ctx)
        {
            _context = ctx;
        }
        public string CartId { get; set; }
        public List<ShoppingCart> shopItems { get; set; }

        public static EFCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<CraftDbContext>();
            string craftId = session.GetString("CraftId") ?? Guid.NewGuid().ToString();
            session.SetString("CraftId", craftId);
            return new EFCart(context)
            {
                CartId = craftId
            };
        }
        public void AddToCraft(Craft craft)
        {
            _context.ShoppingCarts.Add(new ShoppingCart
            {
                ShoppingCartId = CartId,
                Craft = craft,
                Price = craft.Price
            });
            _context.SaveChanges();
        }
        public List<ShoppingCart> getItems()
        {
            return _context.ShoppingCarts.Where(e => e.ShoppingCartId == CartId).Include(c => c.Craft).ToList();
        }

    }
}
