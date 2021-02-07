using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Codesmith.MvcSample.Web.Models;

namespace Codesmith.MvcSample.Web.Infrastructure
{
    public class UserModelBuilder
    {
        public List<MenuModel> Build()
        {
            return SampleData.GetMenu();
        }
    }
}