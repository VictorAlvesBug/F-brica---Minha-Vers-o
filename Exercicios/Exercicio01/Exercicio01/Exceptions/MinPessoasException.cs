using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Exceptions
{
    class MinPessoasException : Exception
    {
        public MinPessoasException()
        {
        }

        public MinPessoasException(string message) : base(message)
        {
        }
    }
}
