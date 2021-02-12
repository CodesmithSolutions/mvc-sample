using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesmith.MvcSample.BusinessObjects
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsActive { get; set; }
        //public UserRoleType Role { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public UserProfileDto Profile { get; set; }

        public List<IssueDto> AssignedTo { get; set; }
        public List<IssueDto> CreatedBy { get; set; }
    }
}
