using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect.Domain.Exceptions
{
    public class ConnectException : Exception
    {
        public ConnectException(string message) : base(message) { }
    }
}
