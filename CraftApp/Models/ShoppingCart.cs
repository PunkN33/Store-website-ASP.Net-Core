using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Craft Craft { get; set; }
        public decimal Price { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
