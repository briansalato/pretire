using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pretire.Routing
{
    public static class UrlHelperExtension
    {
        public static string Salary_New(this UrlHelper urlHelper)
        {
            return urlHelper.Action("New", "Salary");
        }

        public static string Salary_ByYear(this UrlHelper urlHelper)
        {
            return urlHelper.Action("ByYear", "Salary");
        }
    }
}