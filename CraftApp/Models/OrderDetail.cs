using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CraftId { get; set; }
        public decimal Price { get; set; }
        public virtual Craft Craft { get; set; }
        public virtual Order Order { get; set; }
    }
}
