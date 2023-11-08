using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Dto
{
    public class CreateRestaurantDto
    {
        public string Name { get; set; }    

        public string Description { get; set; }

        public RestaurantTypes Type { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;   

        public string Street { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string PostalCity { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string? CreatedById { get; set; }

        public IdentityUser? CreatedBy { get; set; }
    }
}
