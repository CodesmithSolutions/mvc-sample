using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesmith.MvcSample.BusinessObjects
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Byte[] PasswordHash { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
