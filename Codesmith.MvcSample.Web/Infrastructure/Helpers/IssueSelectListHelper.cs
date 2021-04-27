using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codesmith.MvcSample.Web.Infrastructure.Helpers
{
    public class IssueSelectListHelper : IIssueSelectListHelper
    {
        private readonly IIssuePriorityTypeHelper _issuePriorityTypeHelper;
        private readonly IIssueStatusTypeHelper _issueStatusTypeHelper;

        public IssueSelectListHelper(IIssuePriorityTypeHelper issuePriorityTypeHelper,
            IIssueStatusTypeHelper issueStatusTypeHelper)
        {
            _issuePriorityTypeHelper = issuePriorityTypeHelper;
            _issueStatusTypeHelper = issueStatusTypeHelper;
        }

        public SelectList IssuePriorityTypes()
        {
            return _issuePriorityTypeHelper.GetSelectList();
        }

        public SelectList IssueStatusTypes()
        {
            return _issueStatusTypeHelper.GetSelectList();
        }
    }
}