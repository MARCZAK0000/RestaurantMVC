using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Dto
{
    public class ChangePhoneDto
    {
        public string PhoneNumber { get; set; } = string.Empty;

        public string NewPhoneNumber { get; set; } = string.Empty;
    }
}
