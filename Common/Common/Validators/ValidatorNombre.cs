using System;
using Common.Exceptions;

namespace Common.Validators
{
    /// <summary>
    /// Valida un nombre y apellido.
    /// </summary>
    public class ValidatorNombre : IValidator
    {
        private string value;

        public ValidatorNombre(string nombre)
        {
            this.value = nombre;
        }

        #region IValidador Members

        public void Validate()
        {
            if (string.IsNullOrEmpty(value))
                throw new Excepcion("El nombre/apellido está vacío.");
            ValidatorInput.ValidarSoloPalabras("Nombre/apellido", value, false);
        }

        #endregion
    }
}
