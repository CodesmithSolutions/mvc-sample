using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Codesmith.MvcSample.BusinessObjects;

namespace Codesmith.MvcSample.Web.Infrastructure.Helpers
{
    public class IssueStatusTypeHelper : IIssueStatusTypeHelper
    {
        public SelectList GetSelectList()
        {
            var values = Enum.GetValues(typeof(IssueStatusType)).Cast<IssueStatusType>(); ;
            var selectListItems = new List<SelectListItem>();
            foreach(var value in values)
            {
                selectListItems.Add(new SelectListItem
                {
                    Value = value.ToString(),
                    Text = Enum.GetName(typeof(IssueStatusType), value)

                });
            }

            return new SelectList(selectListItems, "Value", "Text");
        }
    }
}