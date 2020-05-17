using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Infrastructure.Exceptions
{
    public class OrderingDomainException : Exception
    {
        // need to override the base class exception
        public OrderingDomainException()
        { }

        public OrderingDomainException(string message) : base(message)
        { }

        public OrderingDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}