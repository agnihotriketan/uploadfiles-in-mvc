using System.Web.Mvc;
using DotNetOpenAuth.AspNet;

namespace GallaryManager.Filters
{
    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.Controller.ViewBag.OnAuthorization = "IAuthorizationFilter.OnAuthorization filter called";
        }
    }

    public class NewAuthenticationFilter : ActionFilterAttribute//, IAuthenticationFilter
    {
        void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.Controller.ViewBag.OnAuthorization = "OnAuthorization.OnAuthorization filter called";
        }
    }

}