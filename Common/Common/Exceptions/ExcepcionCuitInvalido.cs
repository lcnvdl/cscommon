using System;

namespace Common.Exceptions
{
    public sealed class ExcepcionCuitInvalido : Exception
    {
        string cuit;
        /// <summary>
        /// Cuit inválido.
        /// </summary>
        public string Cuit
        {
            get { return cuit; }
            private set { cuit = value; }
        }

        public override string Message
        {
            get
            {
                if (Cuit.Equals(""))
                {
                    return "Error, el cuit ingresado es inválido.";
                }
                else
                {
                    return String.Format("Error, el cuit \"{0}\" es inválido.", Cuit);
                }
            }
        }

        public ExcepcionCuitInvalido()
            : this("")
        { }

        public ExcepcionCuitInvalido(string campo)
        {
            Cuit = campo;
        }
    }
}
