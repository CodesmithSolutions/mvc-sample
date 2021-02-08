using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codesmith.MvcSample.Web.Models
{
    public static class SampleData
    {
        public static List<MenuModel> GetMenu()
        {
            return new List<MenuModel>
            {
                new MenuModel
                {
                    Name = "Home",
                    Url = "/"
                },
                new MenuModel
                {
                    Name = "Users",
                    Url = "/users"
                }
            };
        }
    }
}