using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Exceptions
{
    class MinAndaresException : Exception
    {
        public MinAndaresException()
        {
        }

        public MinAndaresException(string message) : base(message)
        {
        }
    }
}
