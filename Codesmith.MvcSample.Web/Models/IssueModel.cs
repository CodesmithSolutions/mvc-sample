using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Codesmith.MvcSample.BusinessObjects;

namespace Codesmith.MvcSample.Web.Models
{
    public class IssueModel
    {
        public IssueModel()
        {
            Priority = IssuePriorityType.Medium;
            Status = IssueStatusType.Open;
        }

        public int IssueId { get; set; }
        public IssueStatusType Status { get; set; }
        public IssueType Type { get; set; }
        public IssuePriorityType Priority { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AssignedToUserId { get; set; }
        public int CreatedByUserId { get; set; }
    }
}