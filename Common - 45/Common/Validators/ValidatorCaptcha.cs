using System;
using Common.Exceptions;

namespace Common.Validators
{
    /// <summary>
    /// Valida el captcha.
    /// </summary>
    public class ValidatorCaptcha : IValidator
    {
        private string captcha;
        private string captchaIngresado;

        public ValidatorCaptcha(string captcha, string captchaIngresado)
        {
            this.captcha = captcha;
            this.captchaIngresado = captchaIngresado;
        }

        #region IValidador Members

        public void Validate()
        {
            if (string.IsNullOrEmpty(captchaIngresado))
                throw new Excepcion("El captcha ingresado está vacío.");

            if (!captcha.Equals(captchaIngresado, StringComparison.OrdinalIgnoreCase))
                throw new Excepcion("Captcha incorrecto. Por favor, vuelva a intentarlo.");
        }

        #endregion
    }
}
