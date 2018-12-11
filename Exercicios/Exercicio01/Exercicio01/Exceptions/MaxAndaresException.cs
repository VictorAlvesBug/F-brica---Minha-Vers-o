using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Exceptions
{
    class MaxAndaresException : Exception
    {
        public MaxAndaresException()
        {
        }

        public MaxAndaresException(string message) : base(message)
        {
        }
    }
}
