using System.Collections.Generic;
using System.Web.Mvc;
using Codesmith.MvcSample.Web.Models;

namespace Codesmith.MvcSample.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            filterContext.Controller.ViewBag.Menu = SampleData.GetMenu();

            //if (filterContext.Controller.ViewData.Model is BasePageModel model)
            //{
            //    model.Menu = SampleData.GetMenu();
            //    model.User = xxxx;
            //}
        }
    }
}