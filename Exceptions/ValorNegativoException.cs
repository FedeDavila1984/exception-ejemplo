using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class ValorNegativoException : Exception
    {
        public ValorNegativoException()
        {
        }

        public ValorNegativoException(string message)
            : base(message)
        {
        }

        public ValorNegativoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
