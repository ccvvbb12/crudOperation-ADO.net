using System.Web;
using System.Web.Mvc;

namespace crudOperation_ADO.net
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
