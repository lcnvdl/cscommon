using System;

namespace Common.Exceptions
{
    /// <summary>
    /// Excepción controlada.
    /// </summary>
    public class Excepcion : Exception
    {
        object tag;
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public string Title
        {
            get { return (tag ?? "Exception").ToString(); }
            set { tag = value.ToString(); }
        }

        public Excepcion(string mensaje)
            : this(mensaje, null)
        {
        }

        public Excepcion(string mensaje, object tag)
            : base(mensaje)
        {
            Tag = tag;
        }
    }
}
