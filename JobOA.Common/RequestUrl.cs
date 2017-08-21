using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Common
{
    public static class RequestUrl
    {

        public static string IsNowUrl(this string requestUrl,string nowUrl)
        {
            if (requestUrl.Equals(nowUrl, StringComparison.CurrentCultureIgnoreCase))
            {
                return "background";
            }
            else
            {
                return String.Empty;
            }
        }

        public static string IsAmIn(this string requestUrl, string nowUrl)
        {
            if (requestUrl.IndexOf(nowUrl,StringComparison.CurrentCultureIgnoreCase)>0)
            {
                return "am-in";
            }
            else
            {
                return String.Empty;
            }
        }

        public static string IsAmCollapsed(this string requestUrl, string nowUrl)
        {
            if (requestUrl.IndexOf(nowUrl, StringComparison.CurrentCultureIgnoreCase) > 0)
            {
                return String.Empty;
            }
            else
            {
                return "am-collapsed";
            }
        }
    }
}
