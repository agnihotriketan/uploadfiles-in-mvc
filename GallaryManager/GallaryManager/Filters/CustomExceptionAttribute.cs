using System.Web.Mvc;

namespace GallaryManager.Filters
{
    public class CustomExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            filterContext.Controller.ViewBag.OnException = "IExceptionFilter.OnException filter called";
        }
    }
}