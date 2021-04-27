using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codesmith.MvcSample.Web.Infrastructure.Helpers
{
    public interface IIssueSelectListHelper
    {
        SelectList IssuePriorityTypes();

        SelectList IssueStatusTypes();
    }
}