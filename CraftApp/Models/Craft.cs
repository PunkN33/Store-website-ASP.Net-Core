using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.Models
{
    public class Craft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShotDescription { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public bool IsFavorite { get; set; }
        public bool Available { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
