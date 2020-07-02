using System.Web;
using System.Web.Mvc;

namespace Usmp.Fia.WebApiBitacorasV2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
