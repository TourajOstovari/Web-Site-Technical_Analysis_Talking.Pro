using System.Web;
using System.Web.Mvc;

namespace Technical_Analysis_Talking.Pro
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
