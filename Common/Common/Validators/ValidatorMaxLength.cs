using Common.Exceptions;

namespace Common.Validators
{
    public class ValidatorMaxLength : IValidator
    {
        string field;
        string text;
        int length;

        public ValidatorMaxLength(string text, string field, int length)
        {
            this.text = text??"";
            this.field = field;
            this.length = length;
        }

        #region IValidator Members

        public void Validate()
        {
            if (text.Length > length)
            {
                throw new Excepcion("El campo " + field + " excede su longitud máxima. Esta longitud es de " + length + " caracteres.");
            }
        }

        #endregion
    }
    public class ValidatorMinLength : IValidator
    {
        string field;
        string text;
        int length;

        public ValidatorMinLength(string text, string field, int length)
        {
            this.text = text ?? "";
            this.field = field;
            this.length = length;
        }

        #region IValidator Members

        public void Validate()
        {
            if (text.Length < length)
            {
                throw new Excepcion("El campo " + field + " debe tener como mínimo " + length + " caracteres.");
            }
        }

        #endregion
    }
}
