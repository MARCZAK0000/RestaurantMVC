using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ResponseHelper
{
    public interface IResponse
    {
        string ConfirmationToken { get; set; }
        bool Result { get; set; }
        string UserId { get; set; }    
        string Message { get; set; }
    }

    public class Response : IResponse
    {
        public bool Result { get; set; }

        public string ConfirmationToken { get; set; }

        public string UserId { get; set; }

        public string Message { get; set; }
    }
}
