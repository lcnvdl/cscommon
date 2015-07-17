using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Operations
{
    public static class Binary
    {
        public static bool IsEnabled(byte value, byte comparation)
        {
            return (value & comparation) != 0;
        }
    }
}
