using System;
using Common.Exceptions;

namespace Common.Validators
{
    /// <summary>
    /// Valida diferentes inputs.
    /// </summary>
    public static class ValidatorInput
    {

        public static void ValidarSoloLetras(string field, string value)
        {
            foreach (char s in value)
            {
                if (!char.IsLetter(s))
                    throw new Excepcion(string.Format("El campo \"{0}\" debe contener solo letras.", field));
            }
        }

        public static void ValidarSoloDigitos(string field, string value)
        {
            foreach (char s in value)
            {
                if (!char.IsDigit(s))
                    throw new Excepcion(string.Format("El campo \"{0}\" debe contener solo dígitos.", field));
            }
        }

        public static void ValidarSoloLetrasDigitos(string field, string value)
        {
            foreach (char s in value)
            {
                if (!char.IsLetterOrDigit(s))
                    throw new Excepcion(string.Format("El campo \"{0}\" debe contener solo letras y dígitos.", field));
            }
        }

        /// <summary>
        /// Permite solo letras y espacios.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="value"></param>
        public static void ValidarSoloPalabras(string field, string value, bool allowdigits)
        {
            bool letras = false;
            foreach (char s in value)
            {
                if (char.IsLetter(s))
                    letras = true;
                else if (!char.IsWhiteSpace(s))
                {
                    if(!allowdigits || !char.IsDigit(s))
                        throw new Excepcion(string.Format("El campo \"{0}\" debe contener solo letras{1} y espacios.", field, allowdigits?", números":""));
                }
            }

            if(!letras)
                throw new Excepcion(string.Format("El campo \"{0}\" no puede ser solo espacios en blanco.", field));
        }
    }
}
