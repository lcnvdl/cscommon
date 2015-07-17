using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Exceptions;

namespace Common.Validators
{
    /// <summary>
    /// Valida que un monto sea mayor a cero.
    /// </summary>
    public class ValidatorAmount : IValidator
    {
        private float value;
        private string field;

        public ValidatorAmount(float v, string field)
        {
            this.value = v;
            this.field = field;
        }

        #region IValidador Members

        public void Validate()
        {
            if (value <= 0)
                throw new Excepcion("El campo "+field+" debe ser mayor a cero.");
        }

        #endregion
    }
}
