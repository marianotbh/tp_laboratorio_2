using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        string mensajeBase;

        public DniInvalidoException()
            :this("DNI Invalido.")
        { }

        public DniInvalidoException(Exception e)
            :this(e.Message, e)
        { }

        public DniInvalidoException(string message)
            :base(message)
        {
            this.mensajeBase = message;
        }

        public DniInvalidoException(string message, Exception e)
            :base(message, e)
        { }
    }
}
