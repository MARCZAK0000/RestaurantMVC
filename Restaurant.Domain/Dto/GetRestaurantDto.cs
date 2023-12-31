﻿using Restaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Dto
{
    public class GetRestaurantDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public RestaurantTypes Type { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string EncodedName { get; private set; }

        public bool IsEditable { get; set; }    
    }
}
