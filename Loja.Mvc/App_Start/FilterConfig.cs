﻿using Loja.Mvc.Filters;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            filters.Add(new ErrorLogFilter());
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
