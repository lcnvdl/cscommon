using System;
using Common.Exceptions;
using System.Text.RegularExpressions;

namespace Common.Validators
{
    /// <summary>
    /// Valida un usuario.
    /// </summary>
    public class ValidatorEmail : IValidator
    {
        private string mail1;
        private string mail2;

        public ValidatorEmail(string mail)
            : this(mail, mail)
        {
        }

        public ValidatorEmail(string mail1, string mail2)
        {
            this.mail1 = mail1;
            this.mail2 = mail2;
        }

        #region IValidador Members

        public void Validate()
        {
            if (string.IsNullOrEmpty(mail1))
            {
                throw new Excepcion("El correo electrónico esta vacío.");
            }
            if (!mail1.Equals(mail2))
            {
                throw new Excepcion("Los correos electrónicos ingresados no coinciden. Por favor, verifique cuál es el correcto.");
            }

            if (!Regex.IsMatch(mail1, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                throw new Excepcion("El correo electrónico ingresado no es válido.");
            }
        }

        #endregion
    }
}
