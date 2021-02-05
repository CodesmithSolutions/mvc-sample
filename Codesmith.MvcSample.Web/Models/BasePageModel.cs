using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codesmith.MvcSample.Web.Models
{
    public class BasePageModel
    {
        public UserModel User { get; set; }
        public List<MenuModel> Menu { get; set; }
    }
}