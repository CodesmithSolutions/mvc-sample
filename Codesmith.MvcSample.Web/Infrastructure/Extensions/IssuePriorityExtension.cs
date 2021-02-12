using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Codesmith.MvcSample.BusinessObjects;

namespace Codesmith.MvcSample.Web.Infrastructure.Extensions
{
    public static class IssuePriorityExtension
    {
        public static string ColorFormatting(this IssuePriorityType type)
        {
            switch (type)
            {
                case IssuePriorityType.High:
                    return "red";
                case IssuePriorityType.Low:
                    return "green";
                case IssuePriorityType.Medium:
                default:
                    return "black";
            }
        }
    }
}
