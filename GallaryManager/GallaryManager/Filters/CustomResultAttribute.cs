using System.Web.Mvc;

namespace GallaryManager.Filters
{
    public class CustomResultAttribute : FilterAttribute, IResultFilter
    {
        void IResultFilter.OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.OnResultExecuted = "IResultFilter.OnResultExecuted filter called";
        }

        void IResultFilter.OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.OnResultExecuting = "IResultFilter.OnResultExecuting filter called";
        }
    }
}