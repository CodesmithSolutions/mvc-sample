using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesmith.MvcSample.BusinessObjects
{
    public enum UserRoleType
    {
        [Description("Admin")]
        Admin,
        [Description("Standard User")]
        Standard,
        [Description("Super User")]
        Super
    }
}
