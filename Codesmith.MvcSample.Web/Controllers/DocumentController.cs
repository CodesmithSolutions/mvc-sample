using System.Collections.Generic;
using System.Web.Mvc;
using Codesmith.MvcSample.Web.Models;

namespace Codesmith.MvcSample.Web.Controllers
{
    public class DocumentController : Controller
    {
        //private readonly IUserService _userService;

        //public DocumentController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Edit()
        {
            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDocument(DocumentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            return RedirectToAction("Index");
        }
    }
}