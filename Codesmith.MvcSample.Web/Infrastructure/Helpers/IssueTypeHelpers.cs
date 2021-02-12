using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Codesmith.MvcSample.BusinessObjects;

namespace Codesmith.MvcSample.Web.Infrastructure.Helpers
{
    public static class IssueTypeHelpers
    {
        public static SelectList GetSelectList()
        {
            var values = Enum.GetValues(typeof(IssueType)).Cast<IssueType>();
            var selectListItems = new List<SelectListItem>();
            foreach(var value in values)
            {
                selectListItems.Add(new SelectListItem
                {
                    Value = value.ToString(),
                    Text = Enum.GetName(typeof(IssueType), value)

                });
            }

            return new SelectList(selectListItems, "Value", "Text");
        }
    }
}