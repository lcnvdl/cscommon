using System;
using Common.Validators;
using Common.Exceptions;

namespace Common.Validators
{
    /// <summary>
    /// Valida un código de CUIT.
    /// </summary>
    public class ValidatorCuit : IValidator
    {
        string myCuit;

        public ValidatorCuit(string cuit)
        {
            this.myCuit = cuit;
        }

        /// <summary>
        /// Calcula el dígito verificador dado un CUIT completo o sin él.
        /// </summary>
        /// <param name="cuit">El CUIT como String sin guiones</param>
        /// <returns>El valor del dígito verificador calculado.</returns>
        private int CalcularDigitoCuit(string cuit)
        {
            int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            char[] nums = cuit.ToCharArray();
            int total = 0;
            for (int i = 0; i < mult.Length; i++)
            {
                total += int.Parse(nums[i].ToString()) * mult[i];
            }
            var resto = total % 11;
            return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
        }

        /// <summary>
        /// Valida el CUIT ingresado.
        /// </summary>
        /// <param name="cuit" />Número de CUIT como string con o sin guiones
        /// <returns>True si el CUIT es válido y False si no.</returns>
        private bool ValidaCuit(string cuit)
        {
            if (string.IsNullOrEmpty(cuit))
            {
                return false;
            }

            if (cuit.Equals("00000000000"))
                return true;

            //Quito los guiones, el cuit resultante debe tener 11 caracteres.
            cuit = cuit.Replace("-", string.Empty);
            if (cuit.Length != 11)
            {
                return false;
            }
            else
            {
                int calculado = CalcularDigitoCuit(cuit);
                int digito = int.Parse(cuit.Substring(10));
                return calculado == digito;
            }
        }
 

        #region IValidador Members

        /// <summary>
        /// Valida el cuit.
        /// </summary>
        public void Validate()
        {
            if (!ValidaCuit(this.myCuit))
                throw new ExcepcionCuitInvalido(this.myCuit);
        }

        #endregion
    }
}
