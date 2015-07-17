using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Exceptions
{
    public class IncoherenceException: Exception
    {
        public IncoherenceException(string table)
            : base(string.Format("Error, la tabla {0} ha sido actualizada, pero sus cambios no han sido reflejados en el programa.", table))
        {

        }
    }
}
