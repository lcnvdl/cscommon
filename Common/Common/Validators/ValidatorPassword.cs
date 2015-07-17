using System;
using Common.Exceptions;

namespace Common.Validators
{
    /// <summary>
    /// Valida un password.
    /// </summary>
    public class ValidatorPassword : IValidator
    {
        private string pass1;
        private string pass2;

        public ValidatorPassword(string pass)
            : this(pass, pass)
        {
        }

        public ValidatorPassword(string pass1, string pass2)
        {
            this.pass1 = pass1;
            this.pass2 = pass2;
        }

        #region IValidador Members

        public void Validate()
        {
            if (string.IsNullOrEmpty(pass1))
            {
                throw new Excepcion("El campo de contraseña esta vacío.", "Contraseña");
            }

            if (!pass1.Equals(pass2))
            {
                throw new Excepcion("Las contraseñas ingresadas no coinciden. Por favor, verifique cuál es la correcta.", "Contraseña");
            }

            if (pass1.Length < 6)
                throw new Excepcion("La contraseña debe contener como mínimo 6 caracteres.", "Contraseña");
        }

        #endregion
    }
}
