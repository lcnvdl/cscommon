using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Operations
{
    public static class Parsing
    {
        public static float ToFloat(String str)
        {
            if(!str.Contains(',') && !str.Contains('.')) 
                return float.Parse(str);

            string realSep = (float.Parse("0.5") == 0.5f) ? "." : ",";
            string strSep = str.Contains(".") ? "." : ",";

            return float.Parse(str.Replace(strSep, realSep));
        }
    }
}
