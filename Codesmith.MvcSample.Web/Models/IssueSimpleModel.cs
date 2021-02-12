using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Codesmith.MvcSample.BusinessObjects;

namespace Codesmith.MvcSample.Web.Models
{
    public class IssueSimpleModel
    {
        public int IssueId { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public IssuePriorityType Priority { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public string AssignedTo { get; set; }
    }
}