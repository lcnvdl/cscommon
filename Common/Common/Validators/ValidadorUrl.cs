using System;
using Common.Exceptions;

namespace Common.Validators
{
    /// <summary>
    /// Valida un URL.
    /// </summary>
    public class ValidadorUrl : IValidator
    {
        private string value;

        public ValidadorUrl(string url)
        {
            this.value = url;
        }

        #region IValidador Members

        public void Validate()
        {
            if (string.IsNullOrEmpty(value))
                throw new Excepcion("El URL está vacío.");

            if (!value.Contains(".") || value.Contains(".."))
                throw new Excepcion("Dirección de URL inválida.");
        }

        #endregion
    }
}
