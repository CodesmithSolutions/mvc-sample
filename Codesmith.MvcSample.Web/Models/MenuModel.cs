using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codesmith.MvcSample.Web.Models
{
    public class MenuModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public List<MenuModel> SubMenu { get; set; }
    }
}