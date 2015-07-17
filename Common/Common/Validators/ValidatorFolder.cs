using System.IO;
using System.Linq;
using Common.Exceptions;

namespace Common.Validators
{
    public class ValidatorFolder: IValidator
    {
        #region IValidator Members
        string folder;
        string field;

        public ValidatorFolder(string folder, string field)
        {
            this.folder = folder;
            this.field = field;
        }

        public void Validate()
        {
            foreach (char c in Path.GetInvalidPathChars())
            {
                if (folder.Contains(c))
                    throw new Excepcion(string.Format("El campo '{0}' es incorrecto, debido a que no puede tenen el caracter '{1}'.",
                        field, c));
            }
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                if (folder.Contains(c))
                    throw new Excepcion(string.Format("El campo '{0}' es incorrecto, debido a que no puede tenen el caracter '{1}'.",
                        field, c));
            }
        }

        #endregion
    }
}
