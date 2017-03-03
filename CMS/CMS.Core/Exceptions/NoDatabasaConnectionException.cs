using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Core.Exceptions
{
    public class NoDatabasaConnectionException : Exception
    {
        public NoDatabasaConnectionException() { }

        public NoDatabasaConnectionException(string message)
            : base(message) { }

        public NoDatabasaConnectionException(string message, Exception inner)
            : base(message, inner) { }
    }
}