using System;
using Common.Exceptions;

namespace Common.Validators
{
    /// <summary>
    /// Valida que un campo no esté vacío.
    /// </summary>
    public class ValidatorEmptyField : IValidator
    {
        private string field;
        private string value;

        public ValidatorEmptyField(string valor, string campo)
        {
            this.field = campo;
            this.value = valor;
        }

        #region IValidador Members

        public void Validate()
        {
            Validar(field, value);
        }

        #endregion

        public static void Validar(string field, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new Excepcion(string.Format("El campo \"{0}\" está vacío.", field));
        }

        public static void ValidarInt(string field, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new Excepcion(string.Format("El campo \"{0}\" está vacío.", field));

            try
            {
                Validar(field, int.Parse(value));
            }
            catch
            {
                throw new Excepcion(string.Format("El campo \"{0}\" debe contener solo números.", field));
            }
        }

        public static void Validar(string field, int value)
        {
            if (value < 0)
                throw new Excepcion(string.Format("El campo \"{0}\" está vacío.", field));
        }
    }
}
