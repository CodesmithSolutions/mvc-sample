using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesmith.MvcSample.BusinessObjects
{
    public class IssueDto
    {
        public int IssueId { get; set; }
        public IssueType Type { get; set; }
        public IssuePriorityType Priority { get; set; }
        public IssueStatusType Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatedByUserId { get; set; }
        public UserDto CreatedBy { get; set; }
        public UserDto AssignedTo { get; set; }
        public int? AssignedToUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
