using Restaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Dto
{
    public class EditRestaurantDto
    {
        public string? OldName { get; set; }
        
        public string NewName { get; set; } 

        public string? OldDescription { get; set; }

        public string? NewDescription { get; set; }

        public RestaurantTypes? OldType {  get; set; }

        public RestaurantTypes NewTypes { get; set; }

        public string? OldStreet { get; set; }

        public string NewStreet { get; set; }

        public string? OldCity { get; set; } 

        public string NewCity { get; set; }

        public string? OldPostalCode { get; set; }

        public string NewPostalCode {  get; set; }  

        public string? OldPostalCity { get; set; }

        public string NewPostalCity { get; set; }
        
        public string? OldPhoneNumber {  get; set; } 

        public string NewPhoneNumber { get; set; }  

        public string? OldEmail { get; set; }  
        
        public string NewEmail { get; set; }    

        public string? EncodedName { get; set; }
    }
}
