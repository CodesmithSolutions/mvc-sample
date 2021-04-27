using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Codesmith.MvcSample.BusinessObjects;

namespace Codesmith.MvcSample.Web.Infrastructure.Helpers
{
    public interface IIssuePriorityTypeHelper
    {
        SelectList GetSelectList();
    }
}