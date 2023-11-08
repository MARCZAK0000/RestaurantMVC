using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Enitites
{
    public class Restaurant
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public RestaurantTypes Type { get; set; }

        public DateTime CreatedTime { get; set; }   = DateTime.Now;

        public ContactDetails ContactDetails { get; set; }  

        public string? CreatedById { get; set; }
        
        public IdentityUser? CreatedBy { get; set; }

        public List<Dishes> Dishes { get; set; }

        public string EncodedName { get; private set; }

        public void EncodeName(string key)
        {
            EncodedName = key;
        }

    }
}
