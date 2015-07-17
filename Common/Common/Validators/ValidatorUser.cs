using System;
using Common.Exceptions;

namespace Common.Validators
{
    /// <summary>
    /// Valida un usuario. Este debe tener como mínimo cuatro caracteres, debe estar compuesto por letras y números, y debe comenzar con una letra.
    /// </summary>
    public class ValidatorUser : IValidator
    {
        private string value;
        private string field;

        public ValidatorUser(string username)
        {
            this.value = username;
            this.field = "nombre de usuario";
        }
        public ValidatorUser(string username, string field)
        {
            this.value = username;
            this.field = field;
        }

        #region IValidador Members

        public void Validate()
        {
            if (string.IsNullOrEmpty(value))
                throw new Excepcion("El campo '" + field + "' está vacío.");

            if (value.Length < 4)
                throw new Excepcion("El campo '" + field + "' debe tener como mínimo cuatro caracteres.");

            if (!char.IsLetter(value[0]))
                throw new Excepcion("El campo '" + field + "' debe estar compuesto solo por letras y números, y debe comenzar con una letra.");

            foreach (char c in value)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    throw new Excepcion("El campo '" + field + "' debe estar compuesto solo por letras y números, y debe comenzar con una letra.");
                }
            }
        }

        #endregion
    }
}
