using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Helpers
{
    public class StringToHtml
    {
        public static string Parse(string input)
        {
            string result = 
                //StringHelper.ToUTF8(input)
                input
                    .Replace("\r\n", "\n")
                    .Replace("\n", "<br/>")
                ;

            return result;
        }
    }
}
