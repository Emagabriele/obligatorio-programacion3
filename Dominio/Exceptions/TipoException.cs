using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Exceptions
{
    public class TipoException : Exception
    {
        public TipoException() { }
        public TipoException(string message) : base(message) { }
        public TipoException(string message, Exception ex) : base(message, ex) { }
    }
}
