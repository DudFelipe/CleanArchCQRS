using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchCQRS.Domain.Validation
{
    public class DomainValidation : Exception
    {
        public DomainValidation(string message) : base(message)
        {
        }

        public static void When(bool hasError, string message)
        {
            if (hasError)
                throw new DomainValidation(message);
        }
    }
}
