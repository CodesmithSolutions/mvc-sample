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
            //_userService.GetUserProfile("Test");
            var model = new DocumentsViewModel
            {
                Menu = SampleData.GetMenu()
            };

            return View(model);
        }

        public ActionResult Edit()
        {
            var model = new DocumentViewModel
            {
                Menu = SampleData.GetMenu()
            };
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDocument(DocumentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Menu = SampleData.GetMenu();
                return View("Edit", model);
            }

            return RedirectToAction("Index");
        }
    }
}