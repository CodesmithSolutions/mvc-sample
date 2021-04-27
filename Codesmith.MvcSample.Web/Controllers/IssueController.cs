using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;
using AutoMapper;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.Services;
using Codesmith.MvcSample.Services.Contracts;
using Codesmith.MvcSample.Web.Infrastructure.Helpers;
using Codesmith.MvcSample.Web.Models;

namespace Codesmith.MvcSample.Web.Controllers
{
    [Authorize]
    public class IssueController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IIssueService _issueService;
        private readonly IIssueSelectListHelper _selectListHelper;

        public IssueController(IMapper mapper, IUserService userService, 
            IIssueService issueService, 
            IIssueSelectListHelper selectListHelper)
        {
            _mapper = mapper;
            _userService = userService;
            _issueService = issueService;
            _selectListHelper = selectListHelper;
        }

        [HttpGet, Route("issues", Name = "issues")]
        public ActionResult Index()
        {
            var issues = _issueService.GetIssues();
            return View("Index", _mapper.Map<List<IssueSimpleModel>>(issues));
        }

        [HttpGet, Route("issues/new")]
        public ActionResult Create()
        {
            return View("Edit", new IssueModel( ));
        }

        [HttpGet, Route("issues/{issueId:int}")]
        public ActionResult Edit(int issueId)
        {
            var issue = _issueService.GetIssueById(issueId);

            return View("Edit", _mapper.Map<IssueModel>(issue));
        }

        [HttpPost, Route("issues/update")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(IssueModel issue)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", issue);
            }

            _issueService.UpdateIssue(_mapper.Map<IssueDto>(issue));

            return RedirectToAction("Index");
        }

        [HttpGet, Route("issues/{issueId:int}/assign")]
        public ActionResult Assign(int issueId)
        {
            var helper = new UserSelectListHelpers(_userService);
            ViewBag.UserSelectList = helper.GetSelectList();

            var user = _issueService.GetIssueById(issueId);
            return View("Assign", _mapper.Map<IssueModel>(user));
        }

        [HttpPost, Route("issues/assign")]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(IssueModel model)
        {
            _issueService.AssignIssueById(model.IssueId, model.AssignedToUserId.Value);
            return RedirectToAction("Index");
        }
    }
}