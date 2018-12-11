using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Exceptions
{
    class MaxPessoasException : Exception
    {
        public MaxPessoasException()
        {
        }

        public MaxPessoasException(string message) : base(message)
        {
        }
    }
}
