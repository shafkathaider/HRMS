using System;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;

namespace PayRoll.Core.Model.Utility.ActionFilters
{
    public class CheckSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var rd = HttpContext.Current.Session["RD"] as ReportDocument;
            if (rd != null)
            {
                rd.Close();
                rd.Dispose();
                GC.Collect();
            }

            if (CurrentSession.GetCurrentSession() == null)
            {
                string redirectUrl = string.Format("~/Login/Logout");
                filterContext.Result = new RedirectResult(redirectUrl);
            }
        }
    }
}