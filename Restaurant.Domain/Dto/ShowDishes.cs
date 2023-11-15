using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Dto
{
    public class ShowDishes
    {
        public string Name { get; set; }

        public string Describition { get; set; }

        public decimal Price { get; set; }

        public string EncodedName { get; set; } 

        public string RestaurantName { get; set; }
    }
}
