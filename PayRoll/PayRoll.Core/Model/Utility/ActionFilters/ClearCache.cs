﻿using System;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Core.Model.Utility.ActionFilters
{
    public class ClearCache : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
           filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
           filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
           filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
           filterContext.HttpContext.Response.Cache.SetNoStore();
        }
    }
}
