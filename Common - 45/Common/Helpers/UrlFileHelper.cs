using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Common.Helpers
{
    public static class URLFileHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverPath"></param>
        /// <returns></returns>
        public static string ParsePath(string serverPath)
        {
            return HttpContext.Current.Server.MapPath(serverPath);
        }
    }
}
