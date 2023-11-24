using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Exceptions
{
    [Serializable]
    public class SavingToDbException : Exception
    {
        public SavingToDbException(string? message) : base(message)
        {

        }
    }
}
