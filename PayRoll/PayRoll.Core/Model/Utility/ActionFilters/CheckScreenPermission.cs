using System;
using System.Linq;
using System.Web.Mvc;

namespace PayRoll.Core.Model.Utility.ActionFilters
{
   public class CheckScreenPermission:ActionFilterAttribute
    {
       //public Int32 ScreenId { get; set; }
       //public override void OnActionExecuting(ActionExecutingContext filterContext)
       //{
       //    var session = CurrentSession.GetCurrentSession();

       //    if (session != null)
       //    {
       //        var screenList = session.RoleWiseScreenList;
       //        var screenExists = screenList.FirstOrDefault(screens => screens.ScreenCode == Convert.ToString(ScreenId));
    
       //    }
       //    else
       //    {
       //        string redirectUrl = string.Format(PayRoll.Core.Model.Utility.Utility.Sso.Equals("0")
       //         ? "~/Login/Logout"
       //         : "~/Home/Logout");
       //        filterContext.Result = new RedirectResult(redirectUrl);
       //    }
       //}
    }
}
