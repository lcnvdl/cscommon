using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Common.Helpers
{
    public class MailCreator
    {
        MailMessage result;

        public MailMessage Mail
        {
            get
            {
                return result;
            }
        }

        public MailCreator()
        {
            result = new MailMessage();
            result.IsBodyHtml = false;
        }

        public MailCreator Html()
        {
            result.IsBodyHtml = true;
            return this;
        }

        public MailCreator Subject(string subject)
        {
            result.Subject = subject;
            return this;
        }

        public MailCreator Body(string body)
        {
            result.Body = body;
            return this;
        }

        public MailCreator Subject(MailPriority priority)
        {
            result.Priority = priority;
            return this;
        }

        public MailCreator To(params string[] destinies)
        {
            foreach (var to in destinies)
            {
                if (!string.IsNullOrEmpty(to))
                {
                    result.To.Add(new MailAddress(to));
                }
            }
            return this;
        }
    }
}
