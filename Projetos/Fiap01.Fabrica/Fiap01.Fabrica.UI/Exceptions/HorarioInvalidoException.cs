using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.UI.Exceptions
{
    public class HorarioInvalidoException : Exception
    {
        public HorarioInvalidoException(String mensagem) : base(mensagem) { }
    }
}
