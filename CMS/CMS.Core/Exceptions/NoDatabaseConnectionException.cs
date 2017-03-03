using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Core.Exceptions
{
    public class NoDatabaseConnectionException : Exception
    {
        public NoDatabaseConnectionException() { }

        public NoDatabaseConnectionException(string message)
            : base(message) { }

        public NoDatabaseConnectionException(string message, Exception inner)
            : base(message, inner) { }
    }
}