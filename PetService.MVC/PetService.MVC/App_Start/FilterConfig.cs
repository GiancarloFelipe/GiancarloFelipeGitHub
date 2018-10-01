using System.Web;
using System.Web.Mvc;

namespace PetService.MVC
{
    /// <summary>
    /// Provides registration for global filters for the PetSure Web Application System.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Represents global filters.
        /// </summary>
        /// <param name="filters">The class that contains global filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}