using System.Web;

namespace PayRoll.Core.Model.Utility
{
    public class CurrentSession
    {
        public static AppSession GetCurrentSession()
        {
            AppSession UserSession;
            if (HttpContext.Current.Session["Session"] != null)
            {
                UserSession = HttpContext.Current.Session["Session"] as AppSession;
            }
            else
            {
                UserSession = null;
                UserSession = HttpContext.Current.Session["Session"] as AppSession;
            }
            return UserSession;
        }


    }
}
