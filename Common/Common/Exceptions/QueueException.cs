using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Exceptions
{
    public class QueueException: Exception
    {
        List<Exception> exceptions = new List<Exception>();

        public bool HasErrors
        {
            get { return exceptions.Count > 0; }
        }

        public QueueException()
        {

        }

        public void Add(Exception ex)
        {
            exceptions.Add(ex);
        }

        public override string Message
        {
            get
            {
                StringBuilder message = new StringBuilder();
                foreach (var ex in exceptions)
                {
                    message.AppendLine(ex.GetType().ToString());
                    message.AppendLine(ex.Message);
                }
                return message.ToString();
            }
        }
    }
}
