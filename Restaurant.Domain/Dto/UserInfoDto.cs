using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Dto
{
    public class UserInfoDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsEmailConfirmed { get; set; }
    }
}
