using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Dto
{
    public class ConfirmEmailDto
    {
        public string Token { get; set; } 

        public string TokenToEmail { get; set; }
        
        public string Email { get; set; }   
    }
}
