using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.HelperServices
{
    public interface IHelperServices
    {
        Task<string> GetGeneratedRandomKeyAsync();
    }
}
