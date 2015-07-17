namespace Common.Validators
{
    /// <summary>
    /// Interface que puede ser utilizada para realizar validaciones.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Realiza una validación, arrojando excepciones en caso de que el 
        /// resultado de la validación sea negativo.
        /// Este método no tiene parámetros para que el mismo pueda ser más
        /// reutilizable. En vez de parámetros, la clase que desea realizar
        /// la validación deberá hacerlo utilizando atributos propios.
        /// </summary>
        void Validate();
    }
}
